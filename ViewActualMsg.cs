using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class ViewActualMsg : ViewModel
    {
        BBOXPower bboxPower = new BBOXPower() { power = 0, voltage = 0, current = 0 };
        BBOXStatus bboxStatus = new BBOXStatus() { SHD_IN = 0, SHD_OUT = 0, TSMS = 0, AIR_N = 0, AIR_P = 0, PRECH_60V = 0, IMD_OK = 0, BMS_OK = 0, SIGNAL_ERROR = 0, SHD_RESET = 0, SHD_EN = 0, POLARITY = 0, FANS = 0, STM_temp = 0 };
        GPSData gpsData = new GPSData() { latitude = 0, latitude_char = "", longitude = 0, longitude_char = "", speed = 0, course = 0, altitude = 0, };
        ECUState ecuState = new ECUState() { ECU_Status = 0, FL_AMK_Status = 0, FR_AMK_Status = 0, RL_AMK_Status = 0, RR_AMK_Status = 0, TempMotor_H = 0, TempInverter_H = 0, TempIGBT_H = 0, };
        BBOXCommand bboxCommand = new BBOXCommand() { FANS = 0, SHD_EN = 0, };
        FUValues1 fuValues1 = new FUValues1() { apps1 = 0, apps2 = 0, brake1 = 0, brake2 = 0, error = 0 };
        Interconnect interconnect = new Interconnect() { car_state = 0, left_w_pump = 0, right_w_pump = 0, brake_red = 0, brake_white = 0, tsas = 0, killswitch_R = 0, killswitch_L = 0, reserve = 0, susp_RR = 0, susp_RL = 0 };
        FUValues2 fuValues2 = new FUValues2() { steer = 0, susp_FL = 0, susp_FR = 0, brake_pos = 0, RTD = 0, BOTS = 0, SHDB = 0, INERTIA_SW = 0, reserve = 0 };
        BMSCommand bmsCommand = new BMSCommand() { BMS_Balanc = 0, BMS_FullMode = 0, BMS_OK = 0, BMS_ONOFF = 0, BMS_CAN = 0 };
        BMSState bmsState = new BMSState() { BMS_Mode = 0, BMS_Faults = 0, CellVolt_L = 0, CellVolt_H = 0, CellTemp_L = 0, CellTemp_H = 0, BMS_Ident = 0 };
        WheelRPM wheelRPM = new WheelRPM() { front_right = 0, front_left = 0, rear_right = 0, rear_left = 0 };
        BMSVoltages bmsVoltages = new BMSVoltages() { BMS_VoltIdent = 0, BMS_Volt1 = 0, BMS_Volt2 = 0, BMS_Volt3 = 0, BMS_Volt4 = 0, BMS_Volt5 = 0, BMS_Volt6 = 0, BMS_Volt7 = 0 };
        BMSTemps bmsTemps = new BMSTemps() { BMS_TempIdent = 0, BMS_Temp1 = 0, BMS_Temp2 = 0, BMS_Temp3 = 0, BMS_Temp4 = 0, BMS_Temp5 = 0, BMS_Temp6 = 0, BMS_Temp7 = 0 };
        BMSBatteryStructure BmsVoltagesList = new BMSBatteryStructure();
        BMSBatteryStructure BmsTemperaturesList = new BMSBatteryStructure();


        public BBOXPower BboxPower
        {
            get { return bboxPower; }
            set
            {
                bboxPower = value;
                OnPropertyChanged(nameof(BboxPower));
            }
        }
        public BBOXStatus BboxStatus
        {
            get { return bboxStatus; }
            set
            {
                bboxStatus = value;
                OnPropertyChanged(nameof(BboxStatus));
            }
        }
        public GPSData GpsData
        {
            get { return gpsData; }
            set
            {
                gpsData = value;
                OnPropertyChanged(nameof(GpsData));
            }
        }
        public ECUState EcuState
        {
            get { return ecuState; }
            set
            {
                ecuState = value;
                OnPropertyChanged(nameof(EcuState));
            }
        }
        public BBOXCommand BboxCommand
        {
            get { return bboxCommand; }
            set
            {
                bboxCommand = value;
                OnPropertyChanged(nameof(BboxCommand));
            }
        }
        public FUValues1 FuValues1
        {
            get { return fuValues1; }
            set
            {
                fuValues1 = value;
                OnPropertyChanged(nameof(FuValues1));
            }
        }
        public Interconnect Interconnect
        {
            get { return interconnect; }
            set
            {
                interconnect = value;
                OnPropertyChanged(nameof(Interconnect));
            }
        }
        public FUValues2 FuValues2
        {
            get { return fuValues2; }
            set
            {
                fuValues2 = value;
                OnPropertyChanged(nameof(FuValues2));
            }
        }
        public BMSCommand BmsCommand
        {
            get { return bmsCommand; }
            set
            {
                bmsCommand = value;
                OnPropertyChanged(nameof(BmsCommand));
            }
        }
        public BMSState BmsState
        {
            get { return bmsState; }
            set
            {
                bmsState = value;
                OnPropertyChanged(nameof(BmsState));
            }
        }
        public WheelRPM WheelRPM
        {
            get { return wheelRPM; }
            set
            {
                wheelRPM = value;
                OnPropertyChanged(nameof(WheelRPM));
            }
        }
        public BMSVoltages BmsVoltages
        {
            get { return bmsVoltages; }
            set
            {
                bmsVoltages = value;
                OnPropertyChanged(nameof(BmsVoltages));
            }
        }
        public BMSTemps BmsTemps
        {
            get { return bmsTemps; }
            set
            {
                bmsTemps = value;
                OnPropertyChanged(nameof(BmsTemps));
            }
        }


        internal void newMsg(Msg msg)
        {
            if (msg.IsBBOXPower) { BboxPower = msg.BBOXPower; }
            if (msg.IsBBOXStatus) { BboxStatus = msg.BBOXStatus; }
            if (msg.IsGPSData) { GpsData = msg.GPSData; }
            if (msg.IsECUState) { EcuState = msg.ECUState; }
            if (msg.IsBBOXCommand) { BboxCommand = msg.BBOXCommand; }
            if (msg.IsFUValues1) { FuValues1 = msg.FUValues1; }
            if (msg.IsInterconnect) { Interconnect = msg.Interconnect; }
            if (msg.IsFUValues2) { FuValues2 = msg.FUValues2; }
            if (msg.IsBMSCommand) { BmsCommand = msg.BMSCommand; }
            if (msg.IsBMSState) { BmsState = msg.BMSState; }
            if (msg.IsWheelRPM) { WheelRPM = msg.WheelRPM; }
            if (msg.IsBMSVoltages) { BmsVoltages = msg.BMSVoltages; setBmsvoltages(BmsVoltages); }
            if (msg.IsBMSTemps) { BmsTemps = msg.BMSTemps; setBmsTemperatures(BmsTemps); }
        }

        private void setBmsvoltages(BMSVoltages bmsVoltages)
        {
            if (bmsVoltages.BMS_VoltIdent == 0)
            {
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id0.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 7)
            {
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id7.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 14)
            {
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id14.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 21)
            {
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id21.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 28)
            {
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id28.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 35)
            {
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id35.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 42)
            {
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id42.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 49)
            {
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id49.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 56)
            {
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id56.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 63)
            {
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id63.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 70)
            {
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id70.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 77)
            {
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id77.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 84)
            {
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id84.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 91)
            {
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id91.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 98)
            {
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id98.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 105)
            {
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id105.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 112)
            {
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id112.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 119)
            {
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id119.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 126)
            {
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id126.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 133)
            {
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id133.Add(bmsVoltages.BMS_Volt7);
            }
            else if (bmsVoltages.BMS_VoltIdent == 140)
            {
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt1);
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt2);
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt3);
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt4);
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt5);
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt6);
                BmsVoltagesList.Id140.Add(bmsVoltages.BMS_Volt7);
            }
        }

        private void setBmsTemperatures(BMSTemps bmsTemps)
        {
            if (bmsTemps.BMS_TempIdent == 0)
            {
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id0.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 7)
            {
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id7.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 14)
            {
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id14.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 21)
            {
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id21.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 28)
            {
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id28.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 35)
            {
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id35.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 42)
            {
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id42.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 49)
            {
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id49.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 56)
            {
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id56.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 63)
            {
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id63.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 70)
            {
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id70.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 77)
            {
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id77.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 84)
            {
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id84.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 91)
            {
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id91.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 98)
            {
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id98.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 105)
            {
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id105.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 112)
            {
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id112.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 119)
            {
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id119.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 126)
            {
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id126.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 133)
            {
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id133.Add(bmsTemps.BMS_Temp7);
            }
            else if (bmsTemps.BMS_TempIdent == 140)
            {
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp1);
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp2);
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp3);
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp4);
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp5);
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp6);
                BmsTemperaturesList.Id140.Add(bmsTemps.BMS_Temp7);
            }
        }



    }
    
}
