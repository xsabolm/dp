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

        Model model;
        Boolean isLiveData = false;
        ObserverMeranie observerMeranie;
        ViewMeranie viewMeranie;

        private AppController()
        {
            this.model = new Model();
            this.viewMeranie = new ViewMeranie(LoadModelFromDataBase.loadMernia());
        }

        public void loadModel(int idMeranie, bool isLiveData)
        {
            this.isLiveData = isLiveData;

            if (isLiveData)
            {
                log.Info("create liveModel");
                model.loadData();
            }
            else
            {
                log.Info("load historyModel");
                model.loadData(idMeranie);

            }

            setObservers();
        }

        private void setObservers()
        {
            observerMeranie = new ObserverMeranie(viewMeranie);
            observerMeranie.Meranie = model.Meranie;
            model.Meranie.Attach(observerMeranie);
            model.Meranie.Notify();
            model.Meranie.Notify();
        }
    }
}
