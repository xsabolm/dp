using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DP_WpfApp
{
    public class ViewMensuration : ViewModel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private String detailsInformation = "";
        private String detailsInformationDiscipline = "";
        private String mensurationLocality = "";
        private String mensurationComment = "";
        private String disciplineComment = "";
        private String disciplineName = "";

        public ViewMensuration(List<Mensuration> allMensuration)
        {
            allMensuration.ForEach((item => comboboxListMensuration.Add(new ComboboxValue { ID = item.ID, Label = item.StartTime.ToLongTimeString() })));
        }

        public void refreshMensuration()
        {
            comboboxListMensuration.Clear();
            AppController.get.Model.AllMensurations.ForEach((item => comboboxListMensuration.Add(new ComboboxValue { ID = item.ID, Label = item.StartTime.ToLongTimeString() })));
        }

        public void setDisciplineCombobox(List<Discipline> disciplines)
        {
            comboboxListDiscipline.Clear();
            disciplines.ForEach((item =>
            {
                if (item.Name.Equals(""))
                {
                    comboboxListDiscipline.Add(new ComboboxValue { ID = item.ID, Label = item.ID + " No Name" });
                }
                else
                {
                    comboboxListDiscipline.Add(new ComboboxValue { ID = item.ID, Label = item.Name });
                }
            }));
        }

        public ObservableCollection<ComboboxValue> comboboxListMensuration { get; } = new ObservableCollection<ComboboxValue>();
        public ObservableCollection<ComboboxValue> comboboxListDiscipline { get; } = new ObservableCollection<ComboboxValue>();

        private ComboboxValue currentSelectionFromCombobox;

        public void viewNewMeranie(Mensuration mensuration)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Mensuration ID: " + mensuration.ID);
            builder.AppendLine();
            builder.Append("Time of mensuration: " + mensuration.StartTime.ToLongDateString());
            builder.AppendLine();
            builder.Append("Locality: " + mensuration.Locality);
            builder.AppendLine();
            builder.Append("Comment: " + mensuration.Comment);
            builder.AppendLine();
            builder.Append("Count of discipline: " + mensuration.ListDiscipline.Count);

            DetailsInformation = builder.ToString();
        }

        public void viewNewDiscipline(Discipline discipline)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Discipline ID: " + discipline.ID);
            builder.AppendLine();
            builder.Append("Name of discipline: " + discipline.Name);
            builder.AppendLine();
            builder.Append("Comment: " + discipline.Comment);
            builder.AppendLine();
            builder.Append("Count of runs: " + discipline.ListRuns.Count);

            DetailsInformationDiscipline = builder.ToString();
        }

        public string DetailsInformation
        {
            get { return detailsInformation; }
            set
            {
                if (detailsInformation != value)
                {
                    detailsInformation = value;
                    OnPropertyChanged(nameof(DetailsInformation));
                }
            }
        }

        public string DetailsInformationDiscipline
        {
            get { return detailsInformationDiscipline; }
            set
            {
                if (detailsInformationDiscipline != value)
                {
                    detailsInformationDiscipline = value;
                    OnPropertyChanged(nameof(DetailsInformationDiscipline));
                }
            }
        }

        public string DisciplineName
        {
            get { return disciplineName; }
            set
            {
                if (disciplineName != value)
                {
                    disciplineName = value;
                    OnPropertyChanged(nameof(DisciplineName));
                }
            }
        }

        public string DisciplineComment
        {
            get { return disciplineComment; }
            set
            {
                if (disciplineComment != value)
                {
                    disciplineComment = value;
                    OnPropertyChanged(nameof(DisciplineComment));
                }
            }
        }

        public string MensurationComment
        {
            get { return mensurationComment; }
            set
            {
                if (mensurationComment != value)
                {
                    mensurationComment = value;
                    OnPropertyChanged(nameof(MensurationComment));
                }
            }
        }

        internal void setDisciplinePartOfView()
        {
            AppController.get.Model.Mensuration.ListDiscipline.ForEach(discipline =>
            {
                if (discipline.ID == CurrentSelectionFromDisciplineCombobox.ID)
                {
                    viewNewDiscipline(discipline);
                    DisciplineComment = discipline.Comment;
                    DisciplineName = discipline.Name;
                }
            });
        }

        public string MensurationLocality
        {
            get { return mensurationLocality; }
            set
            {
                if (mensurationLocality != value)
                {
                    mensurationLocality = value;
                    OnPropertyChanged(nameof(MensurationLocality));
                }
            }
        }

        public ComboboxValue CurrentSelectionFromCombobox
        {
            get { return currentSelectionFromCombobox; }
            set
            {
                currentSelectionFromCombobox = value;

                OnPropertyChanged(nameof(CurrentSelectionFromCombobox));
            }
        }

        private ComboboxValue currentSelectionFromDisciplineCombobox;

        public ComboboxValue CurrentSelectionFromDisciplineCombobox
        {
            get { return currentSelectionFromDisciplineCombobox; }
            set
            {
                currentSelectionFromDisciplineCombobox = value;
                OnPropertyChanged(nameof(CurrentSelectionFromDisciplineCombobox));
            }
        }
    }
}
