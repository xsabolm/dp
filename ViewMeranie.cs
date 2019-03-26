using System;
using System.Collections.Generic;
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
            setListsFroCombobox(allMerania);
        }


        private String detailsInformation = "TEST";
        public List<String> comboboxListEntries;
        public List<int> comboboxListIds;

        public void viewNewMeranie(Meranie meranie) {
            StringBuilder builder = new StringBuilder();
            builder.Append("Meranie ID: " + meranie.ID);
            builder.AppendLine();
            builder.Append("Cas merania: " + meranie.CasMerania);
            builder.AppendLine();
            builder.Append("Detaily: " + meranie.Detaily);
            builder.AppendLine();
            builder.Append("Pocet disciplin: " + meranie.listDisciplin.Count);

            DetailsInformation = builder.ToString();
            log.Info("Change textbox text");

        }

        public void setListsFroCombobox(List<Meranie> allMerania)
        {
            comboboxListEntries = new List<String>();
            comboboxListIds = new List<int>();

            foreach (Meranie m in allMerania)
            {
                comboboxListEntries.Add("Meranie ID:" + m.ID + "/ Datum:" + m.CasMerania);
                comboboxListIds.Add(m.ID);
            }
        }

        public string DetailsInformation
        {
            get { return detailsInformation; }
            set
            {
                if (detailsInformation != value)
                {
                    detailsInformation = value;
                    OnPropertyChanged("DetailsInformation");
                }
            }
        }
    }
}
