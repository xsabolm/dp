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
        public Discipline SelectedDiscipline { get => selectedDisciplina; set => selectedDisciplina = value; }
        public Run SelectedRun { get => selectedRun; set => selectedRun = value; }
        public bool ModelWasSaved { get => modelWasSaved; set => modelWasSaved = value; }

        Model model;
        ProcessingLiveData processingLiveData;
        LiveConnection liveConnection;
        Boolean isLiveData = IsLiveConnection;
        Boolean modelWasSaved = false;
        Discipline selectedDisciplina;
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
        }

        internal void saveToDataBase()
        {
            if ((Model.Mensuration != null) && (IsLiveData))
            {
                DataBaseServices.insertModel(Model.Mensuration);
                ModelWasSaved = true;
            }
        }

        public void loadModel(int idMeranie)
        {
            if (IsLiveData)
            {
                MessageBoxes.saveExistingModel(Model.Mensuration);
            }

            IsLiveData = !IsLiveConnection;
            ViewDisciplina.setView(IsLiveData);
            model.loadAllMeranieFromDatabase(idMeranie);
            setObservers();
        }

        public void loadModel(String label)
        {
            IsLiveData = IsLiveConnection;
            ProcessingLiveData = new ProcessingLiveData();
            LiveConnection = new LiveConnection(label);
            setLiveConnectionView();
            model.createModel();
            //setObservers();
        }

        private void setObservers()
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
            List<Run> ListOkruhov = null;

            Model.Mensuration.ListDiscipline.ForEach(disciplina =>
            {
                if (disciplina.ID == disciplinaID)
                {
                    SelectedDiscipline = disciplina;
                    ListOkruhov = disciplina.ListRuns;
                }
            });
            ListOkruhov.ForEach(okruh =>
            {
                okruh.Attach(new ObserverRun(ViewDisciplina, okruh));
                okruh.Notify();
            });
        }


        internal void setSelectedRun(int ID)
        {
            SelectedDiscipline.ListRuns.ForEach(run =>
            {
                if (run.ID == ID)
                {
                    SelectedRun = run;
                }
            });
            //setMainView();
        }

        internal void setLiveConnectionView()
        {
            ViewDisciplina.setView(IsLiveData);
            ViewLiveConnection.setView(IsLiveConnection);
        }

        internal void closeLiveConnection()
        {
            LiveConnection.closePort();
            LiveConnection = null;
            ViewLiveConnection.setView(!IsLiveConnection);
        }
    }
}
