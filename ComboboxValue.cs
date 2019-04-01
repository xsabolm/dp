using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class ComboboxValue : ViewModel
    {
        private int id;
        private String label;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(ID)); }
        }

        public string Label
        {
            get { return label; }
            set { label = value; OnPropertyChanged(nameof(Label)); }
        }
    }
}
