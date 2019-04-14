using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using connection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DP_WpfApp
{
    public sealed class AppController
    {
        private const bool IsLiveConnection = true;

        private static readonly Lazy<AppController> instance = new Lazy<AppController>(() => new AppController());
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static AppController get { get { return instance.Value; } }

        public ViewMensuration ViewMeranie { get => viewMeranie; set => viewMeranie = value; }
        public ViewDiscipline ViewDisciplina { get => viewDisciplina; set => viewDisciplina = value; }
        internal ViewLiveConnection ViewLiveConnection { get => viewLiveConnection; set => viewLiveConnection = value; }
        public LiveConnection LiveConnection { get => liveConnection; set => liveConnection = value; }
        public ProcessingLiveData ProcessingLiveData { get => processingLiveData; set => processingLiveData = value; }

        public Model Model { get => model; set => model = value; }
        public bool IsLiveData { get => isLiveData; set => isLiveData = value; }
        public SelectedDiscipline SelectedDiscipline { get => selectedDisciplina; set => selectedDisciplina = value; }

        public Run SelectedRun { get => selectedRun; set => selectedRun = value; }
        public ViewMain ViewMain { get => viewMain; set => viewMain = value; }

        ViewMain viewMain;

        Model model;
        ProcessingLiveData processingLiveData;
        LiveConnection liveConnection;
        Boolean isLiveData = IsLiveConnection;
        SelectedDiscipline selectedDisciplina;
        Run selectedRun;

        ViewMensuration viewMeranie;
        ViewDiscipline viewDisciplina;
        ViewLiveConnection viewLiveConnection;

        private AppController()
        {
            IsLiveData = false;
            model = new Model();
            ViewMeranie = new ViewMensuration(LoadModelFromDataBase.loadMensuration());
            ViewDisciplina = new ViewDiscipline();
            ViewLiveConnection = new ViewLiveConnection();
            SelectedDiscipline = null;
            ViewMain = new ViewMain();
        }

        internal void saveToDataBase()
        {
            if ((Model.Mensuration != null) && (IsLiveData))
            {
                DataBaseServices.insertModel(Model.Mensuration);
            }
        }

        public void loadModel(int idMeranie)
        {
            if (IsLiveData) { MessageBoxes.saveExistingModel(Model.Mensuration); }
            IsLiveData = false;
            ViewDisciplina.setView(IsLiveData);
            model.loadAllMeranieFromDatabase(idMeranie);
            setMenusrationObserver();
        }

        public void loadModel(String portName, int boudRate)
        {
            IsLiveData = true;
            ProcessingLiveData = new ProcessingLiveData();
            LiveConnection = new LiveConnection(portName, boudRate);
            setLiveConnectionView();
            model.createModel();
        }

        public Boolean newDiscipline()
        {
            if (IsLiveData)
            {
                LiveConnection.startPort();
                setMainView();
                return true;
            }
            else
            {
                MessageBoxes.didNotSetConnection();
                return false;
            }
        }

        public void closeDiscipline()
        {
            SelectedDiscipline.close();
            model.Mensuration.ListDiscipline.Add(SelectedDiscipline.Discipline);
            LiveConnection.closePort();
            SelectedDiscipline.IsLiveData = false;
        }

        private void setMainView()
        {
            ViewMain.clearView(); 
            SelectedDiscipline = new SelectedDiscipline();
            SelectedDiscipline.IsLiveData = IsLiveData;

            SelectedDiscipline.Attach(new ObserverSelectedDiscipline(ViewMain, SelectedDiscipline));
            SelectedDiscipline.Notify();
        }

        internal void setSelectedRun(int iD)
        {
            SelectedDiscipline.setSelectedRunFromDB(iD);
            ViewMain.clearView();
            SelectedDiscipline.Attach(new ObserverSelectedDiscipline(ViewMain, SelectedDiscipline));
            SelectedDiscipline.Notify();
        }

        private void setMenusrationObserver()
        {
            model.Mensuration.Attach(new ObserverMensuration(viewMeranie, model.Mensuration));
            model.Mensuration.Notify();

            foreach (Discipline disciplina in model.Mensuration.ListDiscipline)
            {
                disciplina.Attach(new ObserverDiscipline(ViewDisciplina, disciplina));
                disciplina.Notify();
            }
        }

        public void setObserverForRun(int disciplinaID)
        {
            ViewDisciplina.resetRuns();
            List<Run> listRun = null;

            Model.Mensuration.ListDiscipline.ForEach(disciplina =>
            {
                if (disciplina.ID == disciplinaID)
                {
                    SelectedDiscipline = new SelectedDiscipline(disciplina);
                    listRun = disciplina.ListRuns;
                }
            });
            listRun.ForEach(run =>
            {
                run.Attach(new ObserverRun(ViewDisciplina, run));
                run.Notify();
            });
        }

        internal void setLiveConnectionView()
        {
            ViewDisciplina.setView(IsLiveData);
            ViewLiveConnection.setView(IsLiveConnection);
        }

        internal void closeLiveConnection()
        {
            IsLiveData = false;
            LiveConnection.closePort();
            LiveConnection = null;
            ViewLiveConnection.setView(IsLiveData);
        }
    }
}
