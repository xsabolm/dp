using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DP_WpfApp
{
    public class SelectedDiscipline : Subject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        Discipline discipline;
        Run selectedRun;
        Run newRun;
        Boolean runWasSelected = false;
        Msg newMsg;

        RunTrack liveRunTrack;
        private Boolean isLiveData = false;
        private Boolean isLiveAndActual = true;
        SelectedMsges selectedMsges;
        private Queue<Msg> queueMsg;

        public Discipline Discipline { get => discipline; set => discipline = value; }
        public Run SelectedRun { get => selectedRun; set => selectedRun = value; }
        public Run NewRun { get => this.newRun; set => this.newRun = value; }
        public Msg NewMsg { get => newMsg; set => newMsg = value; }

        public RunTrack LiveRunTrack { get => liveRunTrack; set => liveRunTrack = value; }

        public bool IsLiveData { get => isLiveData; set => isLiveData = value; }
        public bool IsLiveAndActual { get => isLiveAndActual; set => isLiveAndActual = value; }

        public bool RunWasSelected { get => runWasSelected; set => runWasSelected = value; }
        public Queue<Msg> QueueMsg { get => queueMsg; set => queueMsg = value; }


        public List<BBOXPower> BBOXPowerList { get; } = new List<BBOXPower>();
        public List<BBOXStatus> BBOXStatusList { get; } = new List<BBOXStatus>();
        public List<GPSData> GPSDataList { get; } = new List<GPSData>();
        public List<ECUState> ECUStateList { get; } = new List<ECUState>();
        public List<FUValues1> FUValues1List { get; } = new List<FUValues1>();
        public List<Interconnect> InterconnectList { get; } = new List<Interconnect>();
        public List<FUValues2> FUValues2List { get; } = new List<FUValues2>();
        public List<BMSCommand> BMSCommandList { get; } = new List<BMSCommand>();
        public List<BMSState> BMSStateList { get; } = new List<BMSState>();
        public List<WheelRPM> WheelRPMList { get; } = new List<WheelRPM>();
        public List<BMSVoltages> BMSVoltagesList { get; } = new List<BMSVoltages>();
        public List<BMSTemps> BMSTempsList { get; } = new List<BMSTemps>();
        public List<BBOXCommand> BBOXCommandList { get; } = new List<BBOXCommand>();
        public SelectedMsges SelectedMsges { get => selectedMsges; set => selectedMsges = value; }

        public SelectedDiscipline()
        {
            Discipline = new Discipline();
            NewRun = new Run();
            NewRun.ID = Discipline.ListRuns.Count;
            LiveRunTrack = new RunTrack();
            SelectedRun = NewRun;
            SelectedMsges = new SelectedMsges();
            QueueMsg = new Queue<Msg>();
            SelectedMsges.Attach(new ObserverSelectedMsg(AppController.get.ViewMain, this));
            RunWasSelected = true;
        }

        public SelectedDiscipline(Discipline disciplina)
        {
            Discipline = disciplina;
            LiveRunTrack = new RunTrack();
            SelectedMsges = new SelectedMsges();
            SelectedMsges.Attach(new ObserverSelectedMsg(AppController.get.ViewMain, this));
        }

        internal void setSelectedRunFromDB(int ID)
        {
            Discipline.ListRuns.ForEach(run =>
            {
                if (run.ID == ID)
                {
                    clearLists();
                    SelectedRun = run;
                    RunWasSelected = true;
                    LiveRunTrack.clear();
                    setLists();
                }
            });
        }

        internal void setSelectedRunFromCount(int numberInList)
        {
            if (numberInList == 0)
            {
                if (!IsLiveAndActual)
                {
                    SelectedRun = NewRun;
                    RunWasSelected = true;
                    setLists();
                    QueueMsg.Clear();
                    QueueMsg = new Queue<Msg>(NewRun.ListMsg);
                    Notify();
                    IsLiveAndActual = true;
                }
            }
            else if ((numberInList > 0) && (numberInList <= Discipline.ListRuns.Count))
            {
                IsLiveAndActual = false;
                SelectedRun = Discipline.ListRuns[numberInList - 1];
                //clearLists();
                RunWasSelected = true;
                setLists();
                Notify();
            }
        }



        internal void addNewMsg(JsonMsg jsonMsg)
        {
            if (NewRun != null)
            {
                NewMsg = new Msg(jsonMsg);
                NewRun.ListMsg.Add(NewMsg);
                QueueMsg.Enqueue(NewMsg);

                if (NewMsg.IsGPSData)
                {
                    LiveRunTrack.addNewGpsMsg(NewMsg.GPSData, (NewRun.ListMsg.Count - 1), NewMsg.ReceiptTime);
                }

                if (IsLiveAndActual)
                {
                    SelectedMsges.ActulMsg = NewMsg;
                    SelectedMsges.Notify();
                    Notify();
                }
            }
        }

        private void setLists() { int index = 0; SelectedRun.ListMsg.ForEach(msg => { addToList(msg, index); index++; }); }

        private void addToList(Msg msg, int index)
        {
            if (msg.IsBBOXPower) { BBOXPowerList.Add(msg.BBOXPower); }
            if (msg.IsBBOXStatus) { BBOXStatusList.Add(msg.BBOXStatus); }
            if (msg.IsGPSData) { GPSDataList.Add(msg.GPSData); LiveRunTrack.addNewGpsMsg(msg.GPSData, index, msg.ReceiptTime); }
            if (msg.IsECUState) { ECUStateList.Add(msg.ECUState); }
            if (msg.IsBBOXCommand) { BBOXCommandList.Add(msg.BBOXCommand); }
            if (msg.IsFUValues1) { FUValues1List.Add(msg.FUValues1); }
            if (msg.IsInterconnect) { InterconnectList.Add(msg.Interconnect); }
            if (msg.IsFUValues2) { FUValues2List.Add(msg.FUValues2); }
            if (msg.IsBBOXCommand) { BBOXCommandList.Add(msg.BBOXCommand); }
            if (msg.IsBMSState) { BMSStateList.Add(msg.BMSState); }
            if (msg.IsWheelRPM) { WheelRPMList.Add(msg.WheelRPM); }
            if (msg.IsBMSVoltages) { BMSVoltagesList.Add(msg.BMSVoltages); }
            if (msg.IsBMSTemps) { BMSTempsList.Add(msg.BMSTemps); }
        }

        internal void close()
        {
            NewRun.FinishTime = DateTime.Now;
            Discipline.ListRuns.Add(NewRun);
            IsLiveData = false;
        }

        internal void detectedNewRun(DateTime finishTime)
        {
            if (NewRun != null)
            {
                RunWasSelected = false;
                NewRun.FinishTime = finishTime;
                NewRun.PointList.AddRange(LiveRunTrack.pointList);
                Discipline.ListRuns.Add(NewRun);
                App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                {
                    AppController.get.ViewDisciplina.addToComboboxRuns(NewRun);
                }));
                LiveRunTrack.clear();
                QueueMsg.Clear();
                NewRun = new Run();

                NewRun.ID = Discipline.ListRuns.Count;

                RunWasSelected = true;
            }
        }

        internal void setSelectedMsg(int numberSelectedMsg)
        {
            if (SelectedRun.ListMsg.Count > numberSelectedMsg)
            {
                SelectedMsges.setList(SelectedRun.ListMsg.GetRange(0, numberSelectedMsg));
                SelectedMsges.Notify();
            }
        }
        internal void setSelectedMsg(System.Windows.Point pointFromCanvas)
        {
            if (IsLiveAndActual)
            {
                if (LiveRunTrack.pointList.Count > 0)
                {
                    LiveRunTrack.pointList.ForEach(pointFromList =>
                    {
                        if (AppController.get.ViewMain.ViewLap.comparePoitInListWithRederedPoint(pointFromList, pointFromCanvas))
                        {
                            SelectedMsges.setList(SelectedRun.ListMsg.GetRange(0, pointFromList.MsgNumber));
                            selectedMsges.IsSelectedMsg = true;
                            SelectedMsges.Notify();
                        }
                    });
                }
            }
            else
            {
                if (SelectedRun.PointList.Count > 0)
                {
                    SelectedRun.PointList.ForEach(pointFromList =>
                    {
                        if (AppController.get.ViewMain.ViewLap.comparePoitInListWithRederedPoint(pointFromList, pointFromCanvas))
                        {
                            SelectedMsges.setList(SelectedRun.ListMsg.GetRange(0, pointFromList.MsgNumber));
                            selectedMsges.IsSelectedMsg = true;
                            SelectedMsges.Notify();
                        }
                    });
                }
            }
        }
        internal void reciviedErrorMsg()
        {
            throw new NotImplementedException();
        }
        internal void clean()
        {
            clearLists();
        }
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
