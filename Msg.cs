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
        int id;
        int idDiscipline;
        int idRun;
        DateTime receiptTime;
        JsonMsg jsonMsg;

        public int ID { get => id; set => id = value; }
        public int IDdisciplina { get => idDiscipline; set => idDiscipline = value; }
        public int ID_run { get => idRun; set => idRun = value; }
        public DateTime ReceiptTime { get => receiptTime; set => receiptTime = value; }
        public JsonMsg JsonMsg { get => jsonMsg; set => jsonMsg = value; }

        public Msg(DataRow row)
        {
            ID = Convert.ToInt32(row[DatabaseQueries.ID]);
            ID_run = Convert.ToInt32(row[DatabaseQueries.ID_RUN]);
            ReceiptTime = Convert.ToDateTime(row[DatabaseQueries.RECEIPT_TIME]);  
            setJsonMsg(row);
        }

        public Msg(JsonMsg jsonMsg)
        {
            JsonMsg = jsonMsg;
            ReceiptTime = DateTime.Now;
        }

        public Msg(int id, int idRun, DateTime receiptTime)
        {
            ID = id;
            ID_run = idRun;
            ReceiptTime = receiptTime;
        }

        private void setJsonMsg(DataRow row)
        {
            JsonMsg = new JsonMsg();
            JsonMsg.Data = new List<Data>();
            JsonMsg.Data.Add(new Data());
            if (!row[DatabaseQueries.power].ToString().Equals(""))
            {
                JsonMsg.Data[0].BBOX_power = new BBOXPower();
                JsonMsg.Data[0].BBOX_power.power = Convert.ToInt32(row[DatabaseQueries.power]);
                JsonMsg.Data[0].BBOX_power.current = Convert.ToInt32(row[DatabaseQueries.current_]);
                JsonMsg.Data[0].BBOX_power.voltage = Convert.ToInt32(row[DatabaseQueries.voltage]);
            }

            if (!row[DatabaseQueries.SHD_IN].ToString().Equals(""))
            {
                JsonMsg.Data[0].BBOX_status = new BBOXStatus();
                JsonMsg.Data[0].BBOX_status.SHD_IN = Convert.ToInt32(row[DatabaseQueries.SHD_IN]);
                JsonMsg.Data[0].BBOX_status.SHD_OUT = Convert.ToInt32(row[DatabaseQueries.SHD_OUT]);
                JsonMsg.Data[0].BBOX_status.TSMS = Convert.ToInt32(row[DatabaseQueries.TSMS]);
                JsonMsg.Data[0].BBOX_status.AIR_N = Convert.ToInt32(row[DatabaseQueries.AIR_N]);
                JsonMsg.Data[0].BBOX_status.AIR_P = Convert.ToInt32(row[DatabaseQueries.AIR_P]);
                JsonMsg.Data[0].BBOX_status.PRECH_60V = Convert.ToInt32(row[DatabaseQueries.PRECH_60V]);
                JsonMsg.Data[0].BBOX_status.IMD_OK = Convert.ToInt32(row[DatabaseQueries.IMD_OK]);
                JsonMsg.Data[0].BBOX_status.BMS_OK = Convert.ToInt32(row[DatabaseQueries.BBOXStatus_BMS_OK]);
                JsonMsg.Data[0].BBOX_status.SIGNAL_ERROR = Convert.ToInt32(row[DatabaseQueries.SIGNAL_ERROR]);
                JsonMsg.Data[0].BBOX_status.SHD_RESET = Convert.ToInt32(row[DatabaseQueries.SHD_RESET]);
                JsonMsg.Data[0].BBOX_status.SHD_EN = Convert.ToInt32(row[DatabaseQueries.BBOXStatus_SHD_EN]);
                JsonMsg.Data[0].BBOX_status.POLARITY = Convert.ToInt32(row[DatabaseQueries.POLARITY]);
                JsonMsg.Data[0].BBOX_status.FANS = Convert.ToInt32(row[DatabaseQueries.BBOXStatus_FANS]);
                JsonMsg.Data[0].BBOX_status.STM_temp = Convert.ToInt32(row[DatabaseQueries.STM_temp]);
            }


            if (!row[DatabaseQueries.latitude].ToString().Equals(""))
            {
                JsonMsg.Data[0].GPS_data = new GPSData();
                JsonMsg.Data[0].GPS_data.latitude = Convert.ToInt32(row[DatabaseQueries.latitude]);
                JsonMsg.Data[0].GPS_data.latitude_char = Convert.ToString(row[DatabaseQueries.latitude_char]);
                JsonMsg.Data[0].GPS_data.longitude = Convert.ToInt32(row[DatabaseQueries.longitude]);
                JsonMsg.Data[0].GPS_data.longitude_char = Convert.ToString(row[DatabaseQueries.longitude_char]);
                JsonMsg.Data[0].GPS_data.speed = Convert.ToInt32(row[DatabaseQueries.speed]);
                JsonMsg.Data[0].GPS_data.course = Convert.ToInt32(row[DatabaseQueries.course]);
                JsonMsg.Data[0].GPS_data.altitude = Convert.ToInt32(row[DatabaseQueries.altitude]);
            }

            if (!row[DatabaseQueries.ECU_Status].ToString().Equals(""))
            {
                JsonMsg.Data[0].ECU_State = new ECUState();
                JsonMsg.Data[0].ECU_State.ECU_Status = Convert.ToInt32(row[DatabaseQueries.ECU_Status]);
                JsonMsg.Data[0].ECU_State.FL_AMK_Status = Convert.ToInt32(row[DatabaseQueries.FL_AMK_Status]);
                JsonMsg.Data[0].ECU_State.FR_AMK_Status = Convert.ToInt32(row[DatabaseQueries.FR_AMK_Status]);
                JsonMsg.Data[0].ECU_State.RL_AMK_Status = Convert.ToInt32(row[DatabaseQueries.RL_AMK_Status]);
                JsonMsg.Data[0].ECU_State.RR_AMK_Status = Convert.ToInt32(row[DatabaseQueries.RR_AMK_Status]);
                JsonMsg.Data[0].ECU_State.TempMotor_H = Convert.ToInt32(row[DatabaseQueries.TempMotor_H]);
                JsonMsg.Data[0].ECU_State.TempInverter_H = Convert.ToInt32(row[DatabaseQueries.TempInverter_H]);
                JsonMsg.Data[0].ECU_State.TempIGBT_H = Convert.ToInt32(row[DatabaseQueries.TempIGBT_H]);
            }

            if (!row[DatabaseQueries.BBOXCommand_FANS].ToString().Equals(""))
            {
                JsonMsg.Data[0].BBOX_command = new BBOXCommand();
                JsonMsg.Data[0].BBOX_command.FANS = Convert.ToInt32(row[DatabaseQueries.BBOXCommand_FANS]);
                JsonMsg.Data[0].BBOX_command.SHD_EN = Convert.ToInt32(row[DatabaseQueries.BBOXCommand_SHD_EN]);
            }


            if (!row[DatabaseQueries.apps1].ToString().Equals(""))
            {
                JsonMsg.Data[0].FU_Values_1 = new FUValues1();
                JsonMsg.Data[0].FU_Values_1.apps1 = Convert.ToInt32(row[DatabaseQueries.apps1]);
                JsonMsg.Data[0].FU_Values_1.apps2 = Convert.ToInt32(row[DatabaseQueries.apps2]);
                JsonMsg.Data[0].FU_Values_1.brake1 = Convert.ToInt32(row[DatabaseQueries.brake1]);
                JsonMsg.Data[0].FU_Values_1.brake2 = Convert.ToInt32(row[DatabaseQueries.brake2]);
                JsonMsg.Data[0].FU_Values_1.error = Convert.ToInt32(row[DatabaseQueries.error]);
            }

            if (!row[DatabaseQueries.car_state].ToString().Equals(""))
            {
                JsonMsg.Data[0].Interconnect = new Interconnect();
                JsonMsg.Data[0].Interconnect.car_state = Convert.ToInt32(row[DatabaseQueries.car_state]);
                JsonMsg.Data[0].Interconnect.left_w_pump = Convert.ToInt32(row[DatabaseQueries.left_w_pump]);
                JsonMsg.Data[0].Interconnect.right_w_pump = Convert.ToInt32(row[DatabaseQueries.right_w_pump]);
                JsonMsg.Data[0].Interconnect.brake_red = Convert.ToInt32(row[DatabaseQueries.brake_red]);
                JsonMsg.Data[0].Interconnect.brake_white = Convert.ToInt32(row[DatabaseQueries.brake_white]);
                JsonMsg.Data[0].Interconnect.tsas = Convert.ToInt32(row[DatabaseQueries.tsas]);
                JsonMsg.Data[0].Interconnect.killswitch_R = Convert.ToInt32(row[DatabaseQueries.killswitch_R]);
                JsonMsg.Data[0].Interconnect.killswitch_L = Convert.ToInt32(row[DatabaseQueries.killswitch_L]);
                JsonMsg.Data[0].Interconnect.reserve = Convert.ToInt32(row[DatabaseQueries.Interconnect_reserve]);
                JsonMsg.Data[0].Interconnect.susp_RR = Convert.ToInt32(row[DatabaseQueries.susp_RR]);
                JsonMsg.Data[0].Interconnect.susp_RL = Convert.ToInt32(row[DatabaseQueries.susp_RL]);
            }

            if (!row[DatabaseQueries.steer].ToString().Equals(""))
            {
                JsonMsg.Data[0].FU_Values_2 = new FUValues2();
                JsonMsg.Data[0].FU_Values_2.steer = Convert.ToInt32(row[DatabaseQueries.steer]);
                JsonMsg.Data[0].FU_Values_2.susp_FL = Convert.ToInt32(row[DatabaseQueries.susp_FL]);
                JsonMsg.Data[0].FU_Values_2.susp_FR = Convert.ToInt32(row[DatabaseQueries.susp_FR]);
                JsonMsg.Data[0].FU_Values_2.brake_pos = Convert.ToInt32(row[DatabaseQueries.brake_pos]);
                JsonMsg.Data[0].FU_Values_2.RTD = Convert.ToInt32(row[DatabaseQueries.RTD]);
                JsonMsg.Data[0].FU_Values_2.BOTS = Convert.ToInt32(row[DatabaseQueries.BOTS]);
                JsonMsg.Data[0].FU_Values_2.SHDB = Convert.ToInt32(row[DatabaseQueries.SHDB]);
                JsonMsg.Data[0].FU_Values_2.INERTIA_SW = Convert.ToInt32(row[DatabaseQueries.INERTIA_SW]);
                JsonMsg.Data[0].FU_Values_2.reserve = Convert.ToInt32(row[DatabaseQueries.FUValues2_reserve]);
            }

            if (!row[DatabaseQueries.BMS_Balanc].ToString().Equals(""))
            {
                JsonMsg.Data[0].BMS_Command = new BMSCommand();
                JsonMsg.Data[0].BMS_Command.BMS_Balanc = Convert.ToInt32(row[DatabaseQueries.BMS_Balanc]);
                JsonMsg.Data[0].BMS_Command.BMS_FullMode = Convert.ToInt32(row[DatabaseQueries.BMS_FullMode]);
                JsonMsg.Data[0].BMS_Command.BMS_OK = Convert.ToInt32(row[DatabaseQueries.BMSCommand_BMS_OK]);
                JsonMsg.Data[0].BMS_Command.BMS_ONOFF = Convert.ToInt32(row[DatabaseQueries.BMS_ONOFF]);
                JsonMsg.Data[0].BMS_Command.BMS_CAN = Convert.ToInt32(row[DatabaseQueries.BMS_CAN]);
            }

            if (!row[DatabaseQueries.BMS_Mode].ToString().Equals(""))
            {
                JsonMsg.Data[0].BMS_State = new BMSState();
                JsonMsg.Data[0].BMS_State.BMS_Mode = Convert.ToInt32(row[DatabaseQueries.BMS_Mode]);
                JsonMsg.Data[0].BMS_State.BMS_Faults = Convert.ToInt32(row[DatabaseQueries.BMS_Faults]);
                JsonMsg.Data[0].BMS_State.CellVolt_L = Convert.ToInt32(row[DatabaseQueries.CellVolt_L]);
                JsonMsg.Data[0].BMS_State.CellVolt_H = Convert.ToInt32(row[DatabaseQueries.CellVolt_H]);
                JsonMsg.Data[0].BMS_State.CellTemp_L = Convert.ToInt32(row[DatabaseQueries.CellTemp_L]);
                JsonMsg.Data[0].BMS_State.CellTemp_H = Convert.ToInt32(row[DatabaseQueries.CellTemp_H]);
                JsonMsg.Data[0].BMS_State.BMS_Ident = Convert.ToInt32(row[DatabaseQueries.BMS_Ident]);
            }

            if (!row[DatabaseQueries.front_right].ToString().Equals(""))
            {
                JsonMsg.Data[0].wheel_RPM = new WheelRPM();
                JsonMsg.Data[0].wheel_RPM.front_right = Convert.ToInt32(row[DatabaseQueries.front_right]);
                JsonMsg.Data[0].wheel_RPM.front_left = Convert.ToInt32(row[DatabaseQueries.front_left]);
                JsonMsg.Data[0].wheel_RPM.rear_right = Convert.ToInt32(row[DatabaseQueries.rear_right]);
                JsonMsg.Data[0].wheel_RPM.rear_left = Convert.ToInt32(row[DatabaseQueries.rear_left]);
            }

            if (!row[DatabaseQueries.BMS_VoltIdent].ToString().Equals(""))
            {
                JsonMsg.Data[0].BMS_Voltages = new BMSVoltages();
                JsonMsg.Data[0].BMS_Voltages.BMS_VoltIdent = Convert.ToInt32(row[DatabaseQueries.BMS_VoltIdent]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt1 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt1]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt2 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt2]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt3 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt3]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt4 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt4]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt5 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt5]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt6 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt6]);
                JsonMsg.Data[0].BMS_Voltages.BMS_Volt7 = Convert.ToInt32(row[DatabaseQueries.BMS_Volt7]);
            }

            if (!row[DatabaseQueries.BMS_TempIdent].ToString().Equals(""))
            {
                JsonMsg.Data[0].BMS_Temps = new BMSTemps();
                JsonMsg.Data[0].BMS_Temps.BMS_TempIdent = Convert.ToInt32(row[DatabaseQueries.BMS_TempIdent]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp1 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp1]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp2 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp2]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp3 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp3]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp4 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp4]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp5 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp5]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp6 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp6]);
                JsonMsg.Data[0].BMS_Temps.BMS_Temp7 = Convert.ToInt32(row[DatabaseQueries.BMS_Temp7]);
            }
        }
    }
}
