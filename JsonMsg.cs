using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class JsonMsg
    {
        public int Id { get; set; }
        public Data Data { get; set; }
    }

    public class BBOXPower
    {
        public int power { get; set; } = -1;
        public int current { get; set; } = -1;
        public int voltage { get; set; } = -1;
    }

    public class BBOXStatus
    {
        public int SHD_IN { get; set; } = -1;
        public int SHD_OUT { get; set; } = -1;
        public int TSMS { get; set; } = -1;
        public int AIR_N { get; set; } = -1;
        public int AIR_P { get; set; } = -1;
        public int PRECH_60V { get; set; } = -1;
        public int IMD_OK { get; set; } = -1;
        public int BMS_OK { get; set; } = -1;
        public int SIGNAL_ERROR { get; set; } = -1;
        public int SHD_RESET { get; set; } = -1;
        public int SHD_EN { get; set; } = -1;
        public int POLARITY { get; set; } = -1;
        public int FANS { get; set; } = -1;
        public int STM_temp { get; set; } = -1;
    }

    public class GPSData
    {
        public int latitude { get; set; } = -1;
        public string latitude_char { get; set; } = "x";
        public int longitude { get; set; } = -1;
        public string longitude_char { get; set; } = "y";
        public int speed { get; set; } = -1;
        public int course { get; set; } = -1;
        public int altitude { get; set; } = -1;
    }

    public class ECUState
    {
        public int ECU_Status { get; set; } = -1;
        public int FL_AMK_Status { get; set; } = -1;
        public int FR_AMK_Status { get; set; } = -1;
        public int RL_AMK_Status { get; set; } = -1;
        public int RR_AMK_Status { get; set; } = -1;
        public int TempMotor_H { get; set; } = -1;
        public int TempInverter_H { get; set; } = -1;
        public int TempIGBT_H { get; set; } = -1;
    }

    public class BBOXCommand
    {
        public int FANS { get; set; } = -1;
        public int SHD_EN { get; set; } = -1;
    }

    public class FUValues1
    {
        public int apps1 { get; set; } = -1;
        public int apps2 { get; set; } = -1;
        public int brake1 { get; set; } = -1;
        public int brake2 { get; set; } = -1;
        public int error { get; set; } = -1;
    }

    public class Interconnect
    {
        public int car_state { get; set; } = -1;
        public int left_w_pump { get; set; } = -1;
        public int right_w_pump { get; set; } = -1;
        public int brake_red { get; set; } = -1;
        public int brake_white { get; set; } = -1;
        public int tsas { get; set; }
        public int killswitch_R { get; set; } = -1;
        public int killswitch_L { get; set; } = -1;
        public int reserve { get; set; } = -1;
        public int susp_RR { get; set; } = -1;
        public int susp_RL { get; set; } = -1;
    }

    public class FUValues2
    {
        public int steer { get; set; }
        public int susp_FL { get; set; }
        public int susp_FR { get; set; }
        public int brake_pos { get; set; }
        public int RTD { get; set; }
        public int BOTS { get; set; }
        public int SHDB { get; set; }
        public int INERTIA_SW { get; set; }
        public int reserve { get; set; }
    }

    public class BMSCommand
    {
        public int BMS_Balanc { get; set; }
        public int BMS_FullMode { get; set; }
        public int BMS_OK { get; set; }
        public int BMS_ONOFF { get; set; }
        public int BMS_CAN { get; set; }
    }

    public class BMSState
    {
        public int BMS_Mode { get; set; }
        public int BMS_Faults { get; set; }
        public int CellVolt_L { get; set; }
        public int CellVolt_H { get; set; }
        public int CellTemp_L { get; set; }
        public int CellTemp_H { get; set; }
        public int BMS_Ident { get; set; }
    }

    public class WheelRPM
    {
        public int front_right { get; set; }
        public int front_left { get; set; }
        public int rear_right { get; set; }
        public int rear_left { get; set; }
    }

    public class BMSVoltages
    {
        public int BMS_VoltIdent { get; set; }
        public int BMS_Volt1 { get; set; }
        public int BMS_Volt2 { get; set; }
        public int BMS_Volt3 { get; set; }
        public int BMS_Volt4 { get; set; }
        public int BMS_Volt5 { get; set; }
        public int BMS_Volt6 { get; set; }
        public int BMS_Volt7 { get; set; }
    }

    public class BMSTemps
    {
        public int BMS_TempIdent { get; set; }
        public int BMS_Temp1 { get; set; }
        public int BMS_Temp2 { get; set; }
        public int BMS_Temp3 { get; set; }
        public int BMS_Temp4 { get; set; }
        public int BMS_Temp5 { get; set; }
        public int BMS_Temp6 { get; set; }
        public int BMS_Temp7 { get; set; }
    }

    public class Data
    {
        public BBOXPower BBOX_power { get; set; }
        public BBOXStatus BBOX_status { get; set; }
        public GPSData GPS_data { get; set; }
        public ECUState ECU_State { get; set; }
        public BBOXCommand BBOX_command { get; set; }
        public FUValues1 FU_Values_1 { get; set; }
        public Interconnect Interconnect { get; set; }
        public FUValues2 FU_Values_2 { get; set; }
        public BMSCommand BMS_Command { get; set; }
        public BMSState BMS_State { get; set; }
        public WheelRPM wheel_RPM { get; set; }
        public BMSVoltages BMS_Voltages { get; set; }
        public BMSTemps BMS_Temps { get; set; }
    }
}
