using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DP_WpfApp
{
    public class ViewTables : ViewModel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ObservableCollection<Msg> BBOXPowerList { get; set; }
        public ObservableCollection<Msg> BBOXStatusList { get;  set; }
        public ObservableCollection<Msg> GPSDataList { get; set; }
        public ObservableCollection<Msg> ECUStateList { get; set; }
        public ObservableCollection<Msg> BBOXCommandList { get; set; }
        public ObservableCollection<Msg> FUValues1List { get; set; }
        public ObservableCollection<Msg> InterconnectList { get; set; }
        public ObservableCollection<Msg> FUValues2List { get; set; }
        public ObservableCollection<Msg> BMSCommandList { get; set; }
        public ObservableCollection<Msg> BMSStateList { get; set; }
        public ObservableCollection<Msg> WheelRPMList { get; set; }
        public ObservableCollection<Msg> BMSVoltagesList { get; set; }
        public ObservableCollection<Msg> BMSTempsList { get; set; }

        internal void clearLists()
        {
            BBOXPowerList.Clear();
            BBOXStatusList.Clear();
            GPSDataList.Clear();
            ECUStateList.Clear();
            BBOXCommandList.Clear();
            FUValues1List.Clear();
            InterconnectList.Clear();
            FUValues2List.Clear();
            BMSCommandList.Clear();
            BMSStateList.Clear();
            WheelRPMList.Clear();
            BMSVoltagesList.Clear();
            BMSTempsList.Clear();
        }
    }
}
