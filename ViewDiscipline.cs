using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DP_WpfApp
{
    public class ViewDiscipline : ViewModel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Visibility isHistoricData = Visibility.Hidden;
        private Visibility isLiveData = Visibility.Visible;
        private Visibility isRunCombobox = Visibility.Hidden;

        private ComboboxValue currentSelectionDiscipline;
        private ComboboxValue currentSelectionRun;

        public ObservableCollection<ComboboxValue> comboboxListDisciplines { get; } = new ObservableCollection<ComboboxValue>();
        public ObservableCollection<ComboboxValue> comboboxListRuns { get; } = new ObservableCollection<ComboboxValue>();

        public void setView(Boolean isLiveData)
        {
            if (isLiveData)
            {

                IsLiveData = Visibility.Visible;
                IsHistoricData = Visibility.Hidden;
                IsRunCombobox = Visibility.Hidden;
            }
            else
            {
                IsLiveData = Visibility.Hidden;
                IsHistoricData = Visibility.Visible;
                IsRunCombobox = Visibility.Visible;
                restView();
            }
        }

        public void setVisibleRunCombobox(Boolean beVisibel)
        {
            if (beVisibel)
            {
                comboboxListRuns.Add(new ComboboxValue { ID = 0, Label = "Actual Run" });
                IsRunCombobox = Visibility.Visible;
            }
            else
            {
                IsRunCombobox = Visibility.Hidden;
                resetRuns();
            }
        }

        internal void resetRuns()
        {
            comboboxListRuns.Clear();
        }

        internal void restView()
        {
            comboboxListDisciplines.Clear();
            resetRuns();
        }

        internal void addToComboboxDiscipline(Discipline disciplina)
        {
            comboboxListDisciplines.Add(new ComboboxValue { ID = disciplina.ID, Label = disciplina.ID + " |" + disciplina.Name + " |" + disciplina.Comment });
        }

        internal void addToComboboxRuns(Run run)
        {
            if (run.FinishTime.Year == 1000)
            {
                comboboxListRuns.Add(new ComboboxValue { ID = run.ID, Label = run.ID + " | Start time: " + run.StartTime.ToLongTimeString() + "| Not Finish" });
            }
            else
            {
                comboboxListRuns.Add(new ComboboxValue { ID = run.ID, Label = run.ID + " |" + (run.FinishTime - run.StartTime).Seconds.ToString() });
            }
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

        public Visibility IsRunCombobox
        {
            get { return isRunCombobox; }
            set
            {
                if (isRunCombobox != value)
                {
                    isRunCombobox = value;
                    OnPropertyChanged(nameof(IsRunCombobox));
                }
            }
        }

        public ComboboxValue CurrentSelectionDiscipline
        {
            get { return currentSelectionDiscipline; }
            set
            {
                currentSelectionDiscipline = value;
                OnPropertyChanged(nameof(CurrentSelectionDiscipline));
            }
        }

        public ComboboxValue CurrentSelectionRun
        {
            get { return currentSelectionRun; }
            set
            {
                currentSelectionRun = value;
                OnPropertyChanged(nameof(CurrentSelectionRun));
            }
        }

    }
}
