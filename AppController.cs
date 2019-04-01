using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public sealed class AppController
    {
        private static readonly Lazy<AppController> instance = new Lazy<AppController>(() => new AppController());
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static AppController get { get { return instance.Value; } }

        public ViewMeranie ViewMeranie { get => viewMeranie; set => viewMeranie = value; }
        public ViewDisciplina ViewDisciplina { get => viewDisciplina; set => viewDisciplina = value; }

        public bool IsLiveData { get => isLiveData; set => isLiveData = value; }
        internal ViewLiveConnection ViewLiveConnection { get => viewLiveConnection; set => viewLiveConnection = value; }
        public LiveConnection LiveConnection { get => liveConnection; set => liveConnection = value; }

        Model model;
        Boolean isLiveData = true;
        //ObserverMeranie observerMeranie;
        List<ObserverDisciplina> observerListDisciplina = new List<ObserverDisciplina>();
        ViewMeranie viewMeranie;
        ViewDisciplina viewDisciplina;
        ViewLiveConnection viewLiveConnection;
        LiveConnection liveConnection;

        private AppController()
        {
            model = new Model();
            ViewMeranie = new ViewMeranie(LoadModelFromDataBase.loadMernia());
            ViewDisciplina = new ViewDisciplina();
            ViewLiveConnection = new ViewLiveConnection();
        }

        public void loadModel(int idMeranie, bool isLiveData)
        {
            IsLiveData = isLiveData;
            ViewDisciplina.setView(IsLiveData);
            log.Info("load historyModel");
            model.loadData(idMeranie);
            setObservers();
        }

        public void loadModel(bool isLiveData)
        {
            IsLiveData = isLiveData;
            ViewDisciplina.setView(IsLiveData);
            log.Info("create liveModel");
            model.loadData();
            //setObservers();
        }

        private void setObservers()
        {
            model.Meranie.Attach(new ObserverMeranie(viewMeranie, model.Meranie));
            model.Meranie.Notify();

            foreach (Disciplina disciplina in model.Meranie.listDisciplin)
            {
                disciplina.Attach(new ObserverDisciplina(ViewDisciplina, disciplina));
                disciplina.Notify();
            }
        }

        internal void setLiveConnection(String label)
        {
            log.Info("Port selected:"+label);
            LiveConnection = new LiveConnection(label);
            //AppController.get.loadModel(true);
        }
    }
}
