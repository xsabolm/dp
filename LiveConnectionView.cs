using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    class ViewLiveConnection : ViewModel
    {
        public ViewLiveConnection()
        {
            addToCombobox();
        }

        ComboboxValue currentSelectionPort;
        public ObservableCollection<ComboboxValue> comboboxListPorts { get; } = new ObservableCollection<ComboboxValue>();

        internal void addToCombobox()
        {
            foreach (String portName in SerialPort.GetPortNames())
            {
                comboboxListPorts.Add(new ComboboxValue { Label = portName });
            }
        }

        public ComboboxValue CurrentSelectionPort
        {
            get { return currentSelectionPort; }
            set
            {
                currentSelectionPort = value;
                OnPropertyChanged(nameof(CurrentSelectionPort));
            }
        }

    }
}
