using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    class ObserverRun : Observer
    {
        private Boolean observerIsSet;
        private Run okruh;
        ViewDiscipline view;

        public ObserverRun(ViewDiscipline view, Run o)
        {
            View = view;
            Okruh = o;
            ObserverState = true;
        }

        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        public ViewDiscipline View { get => view; set => view = value; }
        public Run Okruh { get => okruh; set => okruh = value; }

        public override void Update()
        {
            if (ObserverState) { view.addToComboboxOkruhy(Okruh); }
        }

    }
}
