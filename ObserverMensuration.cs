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
        private Mensuration mensuration;
        ViewMensuration view;

        public ObserverMensuration(ViewMensuration view, Mensuration m)
        {
            View = view;
            Mensuration = m;
            ObserverState = true;
        }

        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        public ViewMensuration View { get => view; set => view = value; }
        internal Mensuration Mensuration { get => mensuration; set => mensuration = value; }

        public override void Update()
        {
            if (ObserverState) { view.viewNewMeranie(Mensuration); }
        }

    }
}
