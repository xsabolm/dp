using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DP_WpfApp
{
    class ViewLiveConnection : ViewModel
    {
        private Visibility isLiveConnectionOpened = Visibility.Visible;
        private Visibility isLiveConnectionClosed = Visibility.Hidden;

        public ViewLiveConnection()
        {
            addToCombobox();
        }

        ComboboxValue currentSelectionPort;
        public ObservableCollection<ComboboxValue> comboboxListPorts { get; } = new ObservableCollection<ComboboxValue>();

        internal void addToCombobox()
        {
            comboboxListPorts.Clear();
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

        public Visibility IsLiveConnectionOpened
        {
            get { return isLiveConnectionOpened; }
            set
            {
                if (isLiveConnectionOpened != value)
                {
                    isLiveConnectionOpened = value;
                    OnPropertyChanged(nameof(IsLiveConnectionOpened));
                }
            }
        }

        public Visibility IsLiveConnectionClosed
        {
            get { return isLiveConnectionClosed; }
            set
            {
                if (isLiveConnectionClosed != value)
                {
                    isLiveConnectionClosed = value;
                    OnPropertyChanged(nameof(IsLiveConnectionClosed));
                }
            }
        }

        internal void setView(Boolean isLiveConnection)
        {
            if (isLiveConnection)
            {
                IsLiveConnectionClosed = Visibility.Visible;
                isLiveConnectionOpened = Visibility.Hidden;
            }
            else
            {
                IsLiveConnectionClosed = Visibility.Hidden;
                isLiveConnectionOpened = Visibility.Visible;
            }
        }
    }
}
