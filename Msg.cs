using connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Msg : Subject
    {
        int id =0;
        int idJson;
        int idDiscipline;
        int idRun;
        DateTime receiptTime;
        bool isBBOXPower = false;
        bool isBBOXStatus = false;
        bool isGPSData = false;
        bool isECUState = false;
        bool isBBOXCommand = false;
        bool isFUValues1 = false;
        bool isInterconnect = false;
        bool isFUValues2 = false;
        bool isBMSCommand = false;
        bool isBMSState = false;
        bool isWheelRPM = false;
        bool isBMSVoltages = false;
        bool isBMSTemps = false;

        BBOXPower bBOXPower;
        BBOXStatus bBOXStatus;
        GPSData gPSData;
        ECUState eCUState;
        BBOXCommand bBOXCommand;
        FUValues1 fUValues1;
        Interconnect interconnect;
        FUValues2 fUValues2;
        BMSCommand bMSCommand;
        BMSState bMSState;
        WheelRPM wheelRPM;
        BMSVoltages bMSVoltages;
        BMSTemps bMSTemps;

        public int ID { get => id; set => id = value; }
        public int IDdisciplina { get => idDiscipline; set => idDiscipline = value; }
        public int ID_run { get => idRun; set => idRun = value; }
        public DateTime ReceiptTime { get => receiptTime; set => receiptTime = value; }
        public bool IsBBOXPower { get => isBBOXPower; set => isBBOXPower = value; }
        public bool IsBBOXStatus { get => isBBOXStatus; set => isBBOXStatus = value; }
        public bool IsGPSData { get => isGPSData; set => isGPSData = value; }
        public bool IsECUState { get => isECUState; set => isECUState = value; }
        public bool IsBBOXCommand { get => isBBOXCommand; set => isBBOXCommand = value; }
        public bool IsFUValues1 { get => isFUValues1; set => isFUValues1 = value; }
        public bool IsInterconnect { get => isInterconnect; set => isInterconnect = value; }
        public bool IsFUValues2 { get => isFUValues2; set => isFUValues2 = value; }
        public bool IsBMSCommand { get => isBMSCommand; set => isBMSCommand = value; }
        public bool IsBMSState { get => isBMSState; set => isBMSState = value; }
        public bool IsWheelRPM { get => isWheelRPM; set => isWheelRPM = value; }
        public bool IsBMSVoltages { get => isBMSVoltages; set => isBMSVoltages = value; }
        public bool IsBMSTemps { get => isBMSTemps; set => isBMSTemps = value; }
        public BBOXPower BBOXPower { get => bBOXPower; set => bBOXPower = value; }
        public BBOXStatus BBOXStatus { get => bBOXStatus; set => bBOXStatus = value; }
        public GPSData GPSData { get => gPSData; set => gPSData = value; }
        public ECUState ECUState { get => eCUState; set => eCUState = value; }
        public BBOXCommand BBOXCommand { get => bBOXCommand; set => bBOXCommand = value; }
        public FUValues1 FUValues1 { get => fUValues1; set => fUValues1 = value; }
        public Interconnect Interconnect { get => interconnect; set => interconnect = value; }
        public FUValues2 FUValues2 { get => fUValues2; set => fUValues2 = value; }
        public BMSCommand BMSCommand { get => bMSCommand; set => bMSCommand = value; }
        public BMSState BMSState { get => bMSState; set => bMSState = value; }
        public WheelRPM WheelRPM { get => wheelRPM; set => wheelRPM = value; }
        public BMSVoltages BMSVoltages { get => bMSVoltages; set => bMSVoltages = value; }
        public BMSTemps BMSTemps { get => bMSTemps; set => bMSTemps = value; }
        public int IdJson { get => idJson; set => idJson = value; }

        public Msg(DataRow row)
        {
            ID = Convert.ToInt32(row[DatabaseQueries.ID]);
            ID_run = Convert.ToInt32(row[DatabaseQueries.ID_RUN]);
            ReceiptTime = Convert.ToDateTime(row[DatabaseQueries.RECEIPT_TIME]);
            setJsonMsg(row);
        }

        public Msg(JsonMsg jsonMsg)
        {
            ReceiptTime = DateTime.Now;
            IdJson = jsonMsg.Id;
            setJson(jsonMsg.Data[0]);
        }

        private void setJson(Data data)
        {
            if (data.BBOX_power != null) { IsBBOXPower = true; BBOXPower = data.BBOX_power; };
            if (data.BBOX_status != null) { IsBBOXStatus = true; BBOXStatus = data.BBOX_status; }
            if (data.GPS_data != null) { IsGPSData = true; GPSData = data.GPS_data; }
            if (data.ECU_State != null) { IsECUState = true; ECUState = data.ECU_State; }
            if (data.BBOX_command != null) { IsBBOXCommand = true; BBOXCommand = data.BBOX_command; }
            if (data.FU_Values_1 != null) { IsFUValues1 = true; FUValues1 = data.FU_Values_1; }
            if (data.Interconnect != null) { IsInterconnect = true; Interconnect = data.Interconnect; }
            if (data.FU_Values_2 != null) { IsFUValues2 = true; FUValues2 = data.FU_Values_2; }
            if (data.BMS_Command != null) { IsBMSCommand = true; BMSCommand = data.BMS_Command; }
            if (data.BMS_State != null) { IsBMSState = true; BMSState = data.BMS_State; }
            if (data.wheel_RPM != null) { IsWheelRPM = true; WheelRPM = data.wheel_RPM; }
            if (data.BMS_Voltages != null) { IsBMSVoltages = true; BMSVoltages = data.BMS_Voltages; }
            if (data.BMS_Temps != null) { IsBMSTemps = true; BMSTemps = data.BMS_Temps; }
        }

        public Msg(int id, int idRun, DateTime receiptTime)
        {
            ID = id;
            ID_run = idRun;
            ReceiptTime = receiptTime;
        }

        private void setJsonMsg(DataRow row)
        {

            if (!row[DatabaseQueries.power].ToString().Equals(""))
            {
                IsBBOXPower = true;
                BBOXPower = new BBOXPower();
                BBOXPower.power = Convert.ToInt32(row[DatabaseQueries.power]);
                BBOXPower.current = Convert.ToInt32(row[DatabaseQueries.current_]);
                BBOXPower.voltage = Convert.ToInt32(row[DatabaseQueries.voltage]);
            }

            if (!row[DatabaseQueries.SHD_IN].ToString().Equals(""))
            {
                IsBBOXStatus = true;
                BBOXStatus = new BBOXStatus();
                BBOXStatus.SHD_IN = Convert.ToInt32(row[DatabaseQueries.SHD_IN]);
                BBOXStatus.SHD_OUT = Convert.ToInt32(row[DatabaseQueries.SHD_OUT]);
                BBOXStatus.TSMS = Convert.ToInt32(row[DatabaseQueries.TSMS]);
                BBOXStatus.AIR_N = Convert.ToInt32(row[DatabaseQueries.AIR_N]);
                BBOXStatus.AIR_P = Convert.ToInt32(row[DatabaseQueries.AIR_P]);
                BBOXStatus.PRECH_60V = Convert.ToInt32(row[DatabaseQueries.PRECH_60V]);
                BBOXStatus.IMD_OK = Convert.ToInt32(row[DatabaseQueries.IMD_OK]);
                BBOXStatus.BMS_OK = Convert.ToInt32(row[DatabaseQueries.BBOXStatus_BMS_OK]);
                BBOXStatus.SIGNAL_ERROR = Convert.ToInt32(row[DatabaseQueries.SIGNAL_ERROR]);
                BBOXStatus.SHD_RESET = Convert.ToInt32(row[DatabaseQueries.SHD_RESET]);
                BBOXStatus.SHD_EN = Convert.ToInt32(row[DatabaseQueries.BBOXStatus_SHD_EN]);
                BBOXStatus.POLARITY = Convert.ToInt32(row[DatabaseQueries.POLARITY]);
                BBOXStatus.FANS = Convert.ToInt32(row[DatabaseQueries.BBOXStatus_FANS]);
                BBOXStatus.STM_temp = Convert.ToInt32(row[DatabaseQueries.STM_temp]);
            }


            if (!row[DatabaseQueries.latitude].ToString().Equals(""))
            {
                IsGPSData = true;
                GPSData = new GPSData();
                GPSData.latitude = Convert.ToInt32(row[DatabaseQueries.latitude]);
                GPSData.latitude_char = Convert.ToString(row[DatabaseQueries.latitude_char]);
                GPSData.longitude = Convert.ToInt32(row[DatabaseQueries.longitude]);
                GPSData.longitude_char = Convert.ToString(row[DatabaseQueries.longitude_char]);
                GPSData.speed = Convert.ToInt32(row[DatabaseQueries.speed]);
                GPSData.course = Convert.ToInt32(row[DatabaseQueries.course]);
                GPSData.altitude = Convert.ToInt32(row[DatabaseQueries.altitude]);
            }

            if (!row[DatabaseQueries.ECU_Status].ToString().Equals(""))
            {
                IsECUState = true;
                ECUState = new ECUState();
                ECUState.ECU_Status = Convert.ToInt32(row[DatabaseQueries.ECU_Status]);
                ECUState.FL_AMK_Status = Convert.ToInt32(row[DatabaseQueries.FL_AMK_Status]);
                ECUState.FR_AMK_Status = Convert.ToInt32(row[DatabaseQueries.FR_AMK_Status]);
                ECUState.RL_AMK_Status = Convert.ToInt32(row[DatabaseQueries.RL_AMK_Status]);
                ECUState.RR_AMK_Status = Convert.ToInt32(row[DatabaseQueries.RR_AMK_Status]);
                ECUState.TempMotor_H = Convert.ToInt32(row[DatabaseQueries.TempMotor_H]);
                ECUState.TempInverter_H = Convert.ToInt32(row[DatabaseQueries.TempInverter_H]);
                ECUState.TempIGBT_H = Convert.ToInt32(row[DatabaseQueries.TempIGBT_H]);
            }

            if (!row[DatabaseQueries.BBOXCommand_FANS].ToString().Equals(""))
            {
                IsBBOXCommand = true;
                BBOXCommand = new BBOXCommand();
                BBOXCommand.FANS = Convert.ToInt32(row[DatabaseQueries.BBOXCommand_FANS]);
                BBOXCommand.SHD_EN = Convert.ToInt32(row[DatabaseQueries.BBOXCommand_SHD_EN]);
            }


            if (!row[DatabaseQueries.apps1].ToString().Equals(""))
            {
                IsFUValues1 = true;
                FUValues1 = new FUValues1();
                FUValues1.apps1 = Convert.ToInt32(row[DatabaseQueries.apps1]);
                FUValues1.apps2 = Convert.ToInt32(row[DatabaseQueries.apps2]);
                FUValues1.brake1 = Convert.ToInt32(row[DatabaseQueries.brake1]);
                FUValues1.brake2 = Convert.ToInt32(row[DatabaseQueries.brake2]);
                FUValues1.error = Convert.ToInt32(row[DatabaseQueries.error]);
            }

            if (!row[DatabaseQueries.car_state].ToString().Equals(""))
            {
                IsInterconnect = true;
                Interconnect = new Interconnect();
                Interconnect.car_state = Convert.ToInt32(row[DatabaseQueries.car_state]);
                Interconnect.left_w_pump = Convert.ToInt32(row[DatabaseQueries.left_w_pump]);
                Interconnect.right_w_pump = Convert.ToInt32(row[DatabaseQueries.right_w_pump]);
                Interconnect.brake_red = Convert.ToInt32(row[DatabaseQueries.brake_red]);
                Interconnect.brake_white = Convert.ToInt32(row[DatabaseQueries.brake_white]);
                Interconnect.tsas = Convert.ToInt32(row[DatabaseQueries.tsas]);
                Interconnect.killswitch_R = Convert.ToInt32(row[DatabaseQueries.killswitch_R]);
                Interconnect.killswitch_L = Convert.ToInt32(row[DatabaseQueries.killswitch_L]);
                Interconnect.reserve = Convert.ToInt32(row[DatabaseQueries.Interconnect_reserve]);
                Interconnect.susp_RR = Convert.ToInt32(row[DatabaseQueries.susp_RR]);
                Interconnect.susp_RL = Convert.ToInt32(row[DatabaseQueries.susp_RL]);
            }

            if (!row[DatabaseQueries.steer].ToString().Equals(""))
            {
                IsFUValues2 = true;
                FUValues2 = new FUValues2();
                FUValues2.steer = Convert.ToInt32(row[DatabaseQueries.steer]);
                FUValues2.susp_FL = Convert.ToInt32(row[DatabaseQueries.susp_FL]);
                FUValues2.susp_FR = Convert.ToInt32(row[DatabaseQueries.susp_FR]);
                FUValues2.brake_pos = Convert.ToInt32(row[DatabaseQueries.brake_pos]);
                FUValues2.RTD = Convert.ToInt32(row[DatabaseQueries.RTD]);
                FUValues2.BOTS = Convert.ToInt32(row[DatabaseQueries.BOTS]);
                FUValues2.SHDB = Convert.ToInt32(row[DatabaseQueries.SHDB]);
                FUValues2.INERTIA_SW = Convert.ToInt32(row[DatabaseQueries.INERTIA_SW]);
                FUValues2.reserve = Convert.ToInt32(row[DatabaseQueries.FUValues2_reserve]);
            }

            if (!row[DatabaseQueries.BMS_Balanc].ToString().Equals(""))
            {
                IsBMSCommand = true;
                BMSCommand = new BMSCommand();
                BMSCommand.BMS_Balanc = Convert.ToInt32(row[DatabaseQueries.BMS_Balanc]);
                BMSCommand.BMS_FullMode = Convert.ToInt32(row[DatabaseQueries.BMS_FullMode]);
                BMSCommand.BMS_OK = Convert.ToInt32(row[DatabaseQueries.BMSCommand_BMS_OK]);
                BMSCommand.BMS_ONOFF = Convert.ToInt32(row[DatabaseQueries.BMS_ONOFF]);
                BMSCommand.BMS_CAN = Convert.ToInt32(row[DatabaseQueries.BMS_CAN]);
            }

            if (!row[DatabaseQueries.BMS_Mode].ToString().Equals(""))
            {
                IsBMSState = true;
                BMSState = new BMSState();
                BMSState.BMS_Mode = Convert.ToInt32(row[DatabaseQueries.BMS_Mode]);
                BMSState.BMS_Faults = Convert.ToInt32(row[DatabaseQueries.BMS_Faults]);
                BMSState.CellVolt_L = Convert.ToInt32(row[DatabaseQueries.CellVolt_L]);
                BMSState.CellVolt_H = Convert.ToInt32(row[DatabaseQueries.CellVolt_H]);
                BMSState.CellTemp_L = Convert.ToInt32(row[DatabaseQueries.CellTemp_L]);
                BMSState.CellTemp_H = Convert.ToInt32(row[DatabaseQueries.CellTemp_H]);
                BMSState.BMS_Ident = Convert.ToInt32(row[DatabaseQueries.BMS_Ident]);
            }

            if (!row[DatabaseQueries.front_right].ToString().Equals(""))
            {
                IsWheelRPM = true;
                WheelRPM = new WheelRPM();
                WheelRPM.front_right = Convert.ToInt32(row[DatabaseQueries.front_right]);
                WheelRPM.front_left = Convert.ToInt32(row[DatabaseQueries.front_left]);
                WheelRPM.rear_right = Convert.ToInt32(row[DatabaseQueries.rear_right]);
                WheelRPM.rear_left = Convert.ToInt32(row[DatabaseQueries.rear_left]);
            }

            if (!row[DatabaseQueries.BMS_VoltIdent].ToString().Equals(""))
            {
                IsBMSVoltages = true;
                BMSVoltages = new BMSVoltages();
                BMSVoltages.BMS_VoltIdent = Convert.ToInt32(row[DatabaseQueries.BMS_VoltIdent]);
                BMSVoltages.BMS_Volt1 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt1]);
                BMSVoltages.BMS_Volt2 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt2]);
                BMSVoltages.BMS_Volt3 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt3]);
                BMSVoltages.BMS_Volt4 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt4]);
                BMSVoltages.BMS_Volt5 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt5]);
                BMSVoltages.BMS_Volt6 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt6]);
                BMSVoltages.BMS_Volt7 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt7]);
            }

            if (!row[DatabaseQueries.BMS_TempIdent].ToString().Equals(""))
            {
                IsBMSTemps = true;
                BMSTemps = new BMSTemps();
                BMSTemps.BMS_TempIdent = Convert.ToInt32(row[DatabaseQueries.BMS_TempIdent]);
                BMSTemps.BMS_Temp1 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp1]);
                BMSTemps.BMS_Temp2 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp2]);
                BMSTemps.BMS_Temp3 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp3]);
                BMSTemps.BMS_Temp4 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp4]);
                BMSTemps.BMS_Temp5 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp5]);
                BMSTemps.BMS_Temp6 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp6]);
                BMSTemps.BMS_Temp7 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp7]);
            }
        }
    }
}
