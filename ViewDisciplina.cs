using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DP_WpfApp
{
    public class ViewDisciplina : ViewModel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Visibility isHistoricData = Visibility.Hidden;
        private Visibility isLiveData = Visibility.Visible;
        private ComboboxValue currentSelection;

        public ObservableCollection<ComboboxValue> comboboxListDiscipliny { get; } = new ObservableCollection<ComboboxValue>();

        public void setView(Boolean isLiveData)
        {
            if (isLiveData)
            {
                IsHistoricData = Visibility.Hidden;
                IsLiveData = Visibility.Visible;
            }
            else
            {
                IsHistoricData = Visibility.Visible;
                IsLiveData = Visibility.Hidden;
                restView();
            }
        }

        internal void restView()
        {
            comboboxListDiscipliny.Clear();
        }

        internal void addToCombobox(Disciplina disciplina)
        {
            comboboxListDiscipliny.Add(new ComboboxValue { ID = disciplina.ID, Label = disciplina.ID + " /" + disciplina.Name + " /" + disciplina.TypDiscipiliny });
        }

        public Visibility IsHistoricData
        {
            get { return isHistoricData; }
            set
            {
                if (isHistoricData != value)
                {
                    isHistoricData = value;
                    OnPropertyChanged(nameof(IsHistoricData));
                }
            }
        }

        public Visibility IsLiveData
        {
            get { return isLiveData; }
            set
            {
                if (isLiveData != value)
                {
                    isLiveData = value;
                    OnPropertyChanged(nameof(IsLiveData));
                }
            }
        }

        public ComboboxValue CurrentSelection
        {
            get { return currentSelection; }
            set
            {
                currentSelection = value;
                OnPropertyChanged(nameof(CurrentSelection));
            }
        }

    }
}
