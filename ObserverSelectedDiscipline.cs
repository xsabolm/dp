using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DP_WpfApp
{
    public class ObserverSelectedDiscipline : Observer
    {
        private Boolean observerIsSet;
        SelectedDiscipline selectedDiscipline;
        ViewMain viewMain;

        public ObserverSelectedDiscipline(ViewMain viewMain, SelectedDiscipline selectedDiscipline)
        {
            ObserverState = true;
            SelectedDiscipline = selectedDiscipline;
            ViewMain = viewMain;
        }

        public Boolean ObserverState { get => observerIsSet; set => observerIsSet = value; }
        public SelectedDiscipline SelectedDiscipline { get => selectedDiscipline; set => selectedDiscipline = value; }
        public ViewMain ViewMain { get => viewMain; set => viewMain = value; }

        public override void Update()
        {
            if (ObserverState)
            {
                if (SelectedDiscipline.RunWasSelected)
                {
                    if (SelectedDiscipline.IsLiveData)
                    {
                        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                        {
                            if (SelectedDiscipline.ActualMsg != null)
                            {
                                setView(SelectedDiscipline.ActualMsg);
                            }
                        }));
                    }
                    else
                    {
                        {
                            foreach (Msg msg in SelectedDiscipline.SelectedRun.ListMsg) { setView(msg); }
                        }
                    }
                }
            }
        }

        private void setView(Msg msg)
        {
            if (msg.IsBBOXPower) { ViewMain.BBOXPowerList.Add(msg); ViewMain.ViewGraph.addBBOXPower(msg);}
            if (msg.IsBBOXStatus) { ViewMain.BBOXStatusList.Add(msg); ViewMain.ViewGraph.addBBOXStatus(msg); }
            if (msg.IsGPSData) { ViewMain.GPSDataList.Add(msg); ViewMain.ViewGraph.addGPSData(msg); }
            if (msg.IsECUState) { ViewMain.ECUStateList.Add(msg); ViewMain.ViewGraph.addECUState(msg); }
            if (msg.IsBBOXCommand) { ViewMain.BBOXCommandList.Add(msg); ViewMain.ViewGraph.addBBOXCommand(msg); }
            if (msg.IsFUValues1) { ViewMain.FUValues1List.Add(msg); ViewMain.ViewGraph.addFuValues1(msg); }
            if (msg.IsInterconnect) { ViewMain.InterconnectList.Add(msg); ViewMain.ViewGraph.addInterconnect(msg); }
            if (msg.IsFUValues2) { ViewMain.FUValues2List.Add(msg); ViewMain.ViewGraph.addFuValues2(msg); }
            if (msg.IsBMSCommand) { ViewMain.BMSCommandList.Add(msg); ViewMain.ViewGraph.addBMSCommand(msg); }
            if (msg.IsBMSState) { ViewMain.BMSStateList.Add(msg); ViewMain.ViewGraph.addBMSState(msg); }
            if (msg.IsWheelRPM) { ViewMain.WheelRPMList.Add(msg); ViewMain.ViewGraph.addWheelRPM(msg); }
            if (msg.IsBMSVoltages) { ViewMain.BMSVoltagesList.Add(msg); ViewMain.ViewGraph.addBMSVoltages(msg); }
            if (msg.IsBMSTemps) { ViewMain.BMSTempsList.Add(msg); ViewMain.ViewGraph.addBMSTemps(msg); }
        }
    }
}
