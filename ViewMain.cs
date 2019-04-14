using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class ViewMain
    {
        ViewGraph viewGraph;
        ViewTables viewTables;
        ViewLap viewLap;

        public ViewGraph ViewGraph { get => viewGraph; set => viewGraph = value; }
        public ViewTables ViewTables { get => viewTables; set => viewTables = value; }

        public ObservableCollection<Msg> BBOXPowerList { get; set; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> BBOXStatusList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> GPSDataList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> ECUStateList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> BBOXCommandList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> FUValues1List { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> InterconnectList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> FUValues2List { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> BMSCommandList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> BMSStateList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> WheelRPMList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> BMSVoltagesList { get; } = new ObservableCollection<Msg>();
        public ObservableCollection<Msg> BMSTempsList { get; } = new ObservableCollection<Msg>();

        public ViewMain()
        {
            ViewGraph = new ViewGraph();
            ViewTables = new ViewTables();
            setViewTable();
        }

        internal void addLinesToGraph(String v1, String v2)
        {
            if (ViewGraph.SeriesCollection.Count < 5)
            {
                ViewGraph.addLines(v1, v2);
            }
        }

        private void setViewTable()
        {
            ViewTables.BBOXPowerList = BBOXPowerList;
            ViewTables.BBOXStatusList = BBOXStatusList;
            ViewTables.GPSDataList = GPSDataList;
            ViewTables.ECUStateList = ECUStateList;
            ViewTables.BBOXCommandList = BBOXCommandList;
            ViewTables.FUValues1List = FUValues1List;
            ViewTables.InterconnectList = InterconnectList;
            ViewTables.FUValues2List = FUValues2List;
            ViewTables.BMSCommandList = BMSCommandList;
            ViewTables.BMSStateList = BMSStateList;
            ViewTables.WheelRPMList = WheelRPMList;
            ViewTables.BMSVoltagesList = BMSVoltagesList;
            ViewTables.BMSTempsList = BMSTempsList;
        }
        internal void clearView()
        {
            ViewTables.clearLists();
            ViewGraph.clearLists();
        }
    }
}
