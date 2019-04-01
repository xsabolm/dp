using System;

namespace DP_WpfApp
{
    public class ObserverDisciplina : Observer
    {
        private Boolean observerIsSet;
        private Disciplina disciplina;
        ViewDisciplina view;

        public ObserverDisciplina(ViewDisciplina view, Disciplina d)
        {
            View = view;
            Disciplina = d;
            ObserverIsSet = true;
        }

        public Disciplina Disciplina { get => disciplina; set => disciplina = value; }
        public bool ObserverIsSet { get => observerIsSet; set => observerIsSet = value; }
        public ViewDisciplina View { get => view; set => view = value; }

        public override void Update()
        {
            if (ObserverIsSet) { view.addToCombobox(Disciplina);}
        }

    }
}