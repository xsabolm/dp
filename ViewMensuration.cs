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

        public ViewMensuration(List<Mensuration> allMensuration)
        {
            allMensuration.ForEach((item => comboboxListMensuration.Add(new ComboboxValue { ID = item.ID, Label = item.StartTime.ToLongTimeString() })));
        }

        private String detailsInformation = "";

        public ObservableCollection<ComboboxValue> comboboxListMensuration { get; } = new ObservableCollection<ComboboxValue>();
        private ComboboxValue currentSelectionFromCombobox;

        public void viewNewMeranie(Mensuration mensuration)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Mensuration ID: " + mensuration.ID);
            builder.AppendLine();
            builder.Append("Time of mensuration: " + mensuration.StartTime.ToLongDateString());
            builder.AppendLine();
            builder.Append("Comment: " + mensuration.Comment);
            builder.AppendLine();
            builder.Append("Count of discipline: " + mensuration.ListDiscipline.Count);

            DetailsInformation = builder.ToString();
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

        public ComboboxValue CurrentSelectionFromCombobox
        {
            get { return currentSelectionFromCombobox; }
            set
            {
                currentSelectionFromCombobox = value;
                OnPropertyChanged(nameof(CurrentSelectionFromCombobox));
            }
        }
    }
}
