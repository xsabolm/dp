using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    class ObserverMeranie : Observer
    {
        private String observerID;
        private Boolean observerIsSet;
        private Meranie meranie;
        ViewMeranie view;

        public ObserverMeranie(ViewMeranie view)
        {
            this.view = view;
            ObserverID = "Meranie Observer";
            ObserverState = true;
        }

        public string ObserverID { get => observerID; set => observerID = value; }
        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        internal Meranie Meranie { get => meranie; set => meranie = value; }

        public override void Update()
        {
            if (ObserverState)
            {
                view.viewNewMeranie(Meranie);
            }
        }

    }
}
