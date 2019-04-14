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
        private Run run;
        ViewDiscipline viewTable;

        public ObserverRun(ViewDiscipline viewTable, Run run)
        {
            ViewTabel = viewTable;
            Run = run;
            ObserverState = true;
        }

        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        public ViewDiscipline ViewTabel { get => viewTable; set => viewTable = value; }
        public Run Run { get => run; set => run = value; }

        public override void Update()
        {
            if (ObserverState) {
                viewTable.addToComboboxRuns(Run);
            }
        }

    }
}
