using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DP_WpfApp
{
    public class SelectedDiscipline : Subject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        Discipline discipline;
        Run selectedRun;
        Boolean runWasSelected = false;
        Msg actualMsg;
        Msg selectedMsg;
        public Discipline Discipline { get => discipline; set => discipline = value; }
        public Run SelectedRun { get => selectedRun; set => selectedRun = value; }
        private Boolean isLiveData = false;
        public bool RunWasSelected { get => runWasSelected; set => runWasSelected = value; }

        public List<BBOXPower> BBOXPowerList { get; } = new List<BBOXPower>();
        public List<BBOXStatus> BBOXStatusList { get; } = new List<BBOXStatus>();
        public List<GPSData> GPSDataList { get; } = new List<GPSData>();
        public List<ECUState> ECUStateList { get; } = new List<ECUState>();



        public List<BBOXCommand> BBOXCommandList { get; } = new List<BBOXCommand>();

        internal void reciviedErrorMsg()
        {
            throw new NotImplementedException();
        }

        public List<FUValues1> FUValues1List { get; } = new List<FUValues1>();
        public List<Interconnect> InterconnectList { get; } = new List<Interconnect>();
        public List<FUValues2> FUValues2List { get; } = new List<FUValues2>();
        public List<BMSCommand> BMSCommandList { get; } = new List<BMSCommand>();
        public List<BMSState> BMSStateList { get; } = new List<BMSState>();
        public List<WheelRPM> WheelRPMList { get; } = new List<WheelRPM>();
        public List<BMSVoltages> BMSVoltagesList { get; } = new List<BMSVoltages>();
        public List<BMSTemps> BMSTempsList { get; } = new List<BMSTemps>();
        public Msg ActualMsg { get => actualMsg; set => actualMsg = value; }
        public Msg SelectedMsg { get => selectedMsg; set => selectedMsg = value; }
        public bool IsLiveData { get => isLiveData; set => isLiveData = value; }

        public SelectedDiscipline()
        {
            Discipline = new Discipline();
            SelectedRun = new Run();
            RunWasSelected = true;
        }

        public SelectedDiscipline(Discipline disciplina)
        {
            Discipline = disciplina;
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
                    setLists();
                }
            });
        }

        internal void setSelectedMsg(int numberSelectedMsg)
        {
            if (SelectedRun.ListMsg.Count > numberSelectedMsg)
            {
                SelectedMsg = SelectedRun.ListMsg[numberSelectedMsg];
                SelectedMsg.Notify();
            }
            //SelectedMsg.Notify();
        }

        internal void addNewMsg(JsonMsg jsonMsg)
        {
            if (SelectedRun != null)
            {
                ActualMsg = new Msg(jsonMsg);
                SelectedRun.ListMsg.Add(ActualMsg);
                Notify();                      
            }
        }

        private void setLists() {
            SelectedRun.ListMsg.ForEach(msg => { addToList(msg); });
        }

        private void addToList(Msg msg)
        {
                if (msg.IsBBOXPower) { BBOXPowerList.Add(msg.BBOXPower); }
                if (msg.IsBBOXStatus) { BBOXStatusList.Add(msg.BBOXStatus); }
                if (msg.IsGPSData) { GPSDataList.Add(msg.GPSData); }
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
        internal void clean()
        {
            clearLists();
        }
        internal void close()
        {
            SelectedRun.FinishTime = DateTime.Now;
            Discipline.ListRuns.Add(SelectedRun);
            IsLiveData = false;
        }
    }
}
