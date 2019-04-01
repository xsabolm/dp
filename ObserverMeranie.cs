using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    class ObserverMeranie : Observer
    {
        private Boolean observerIsSet;
        private Meranie meranie;
        ViewMeranie view;

        public ObserverMeranie(ViewMeranie view, Meranie m)
        {
            View = view;
            Meranie = m;
            ObserverState = true;
        }

        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        public ViewMeranie View { get => view; set => view = value; }
        internal Meranie Meranie { get => meranie; set => meranie = value; }

        public override void Update()
        {
            if (ObserverState) { view.viewNewMeranie(Meranie); }
        }

    }
}
