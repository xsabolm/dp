using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DP_WpfApp
{
    public class ViewMeranie : ViewModel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ViewMeranie(List<Meranie> allMerania)
        {
            allMerania.ForEach((item => comboboxListMeranie.Add(new ComboboxValue { ID = item.ID, Label = item.ID + " /" + item.CasMerania })));
        }

        private String detailsInformation = "";

        public ObservableCollection<ComboboxValue> comboboxListMeranie { get; } = new ObservableCollection<ComboboxValue>();
        private ComboboxValue currentSelectionFromCombobox;

        public void viewNewMeranie(Meranie meranie)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Meranie ID: " + meranie.ID);
            builder.AppendLine();
            builder.Append("Cas merania: " + meranie.CasMerania);
            builder.AppendLine();
            builder.Append("Detaily: " + meranie.Detaily);
            builder.AppendLine();
            builder.Append("Pocet disciplin: " + meranie.listDisciplin.Count);

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
