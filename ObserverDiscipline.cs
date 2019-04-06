using System;

namespace DP_WpfApp
{
    public class ObserverDiscipline : Observer
    {
        private Boolean observerIsSet;
        private Discipline disciplina;
        ViewDiscipline view;

        public ObserverDiscipline(ViewDiscipline view, Discipline d)
        {
            View = view;
            Disciplina = d;
            ObserverIsSet = true;
        }

        public Discipline Disciplina { get => disciplina; set => disciplina = value; }
        public bool ObserverIsSet { get => observerIsSet; set => observerIsSet = value; }
        public ViewDiscipline View { get => view; set => view = value; }

        public override void Update()
        {
            if (ObserverIsSet) { view.addToComboboxDiscipliny(Disciplina);}
        }

    }
}