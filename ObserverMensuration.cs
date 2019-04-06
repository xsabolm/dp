using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    class ObserverMensuration : Observer
    {
        private Boolean observerIsSet;
        private Mensuration meranie;
        ViewMensuration view;

        public ObserverMensuration(ViewMensuration view, Mensuration m)
        {
            View = view;
            Meranie = m;
            ObserverState = true;
        }

        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        public ViewMensuration View { get => view; set => view = value; }
        internal Mensuration Meranie { get => meranie; set => meranie = value; }

        public override void Update()
        {
            if (ObserverState) { view.viewNewMeranie(Meranie); }
        }

    }
}
