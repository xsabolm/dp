using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using LiveCharts.Geared;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace DP_WpfApp
{
    public class ChartModel
    {
        public DateTime DateTime { get; set; }
        public int Value { get; set; }
        public int ID { get; set; }

        public ChartModel(DateTime dateTime, int value, int id)
        {
            DateTime = dateTime;
            Value = value;
            id = ID;
        }
    }

    public class ViewGraph
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SeriesCollection SeriesCollection { get => seriesCollection; set => seriesCollection = value; }

        public GearedValues<DateTimePoint> BBOXStatus_SHD_IN_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_VoltIdentt_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_TempIdent_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp1_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp2_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp3_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp4_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp5_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp6_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Temps_BMS_Temp7_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt7_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt6_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt5_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt4_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt3_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt2_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_VoltIdent_BMS_Volt1_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> wheel_RPM_BMS_rear_left_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> wheel_RPM_front_right_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> wheel_RPM_front_left_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> wheel_RPM_rear_right_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_BMS_Mode_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_BMS_Faults_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_CellVolt_L_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_CellVolt_H_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_CellTemp_L_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_CellTemp_H_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_State_BMS_Ident_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Command_BMS_Balanc_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Command_BMS_FullMode_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Command_BMS_OK_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Command_BMS_ONOFF_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BMS_Command_BMS_CAN_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_reserve_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_INERTIA_SW_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_SHDB_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_BOTS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_RTD_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_steer_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_susp_FL_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_susp_FR_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_2_brake_pos_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_car_state_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_left_w_pump_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_right_w_pump_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_brake_red_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_brake_white_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_tsas_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_killswitch_R_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_reserve_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_susp_RR_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> Interconnect_susp_RL_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_1_error_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_1_apps1_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_1_apps2_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_1_brake1_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> FU_Values_1_brake2_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOX_Command_SHD_EN_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOX_Command_FANS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_SHD_OUT_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_TSMS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_AIR_N_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_AIR_P_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_PRECH_60V_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_IMD_OK_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_BMS_OK_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_SIGNAL_ERROR_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_SHD_RESET_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_SHD_EN_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_POLARITY_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_FANS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOXStatus_STM_TEMP_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> GPS_data_LATITUDE_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> GPS_data_LONGTITUDE_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> GPS_data_SPEED_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> GPS_data_COURSE_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> GPS_data_ALTITUDE_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_ECU_STATE_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_FL_AMK_STATUS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_FR_AMK_STATUS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_RL_AMK_STATUS_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_RR_AMK_Status_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_TempMotor_H_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_TempInverter_H_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> ECU_State_TempIGBT_H_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOX_Power_power_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOX_Power_current_List { get; set; } = new GearedValues<DateTimePoint>();
        public GearedValues<DateTimePoint> BBOX_Power_voltage_List { get; set; } = new GearedValues<DateTimePoint>();

        private SeriesCollection seriesCollection = new SeriesCollection();

        internal void addLines(String selectedValue1, String selectedValue2)
        {
            
            seriesCollection.Add(new GLineSeries
            {
                Title = selectedValue1 + ": " + selectedValue2,
                Values = getValueList(selectedValue1, selectedValue2).WithQuality(Quality.Low),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 5
            });
            
           // Formatter = x => new DateTime((long)x).ToString("yyyy");
        }



        private GearedValues<DateTimePoint> getValueList(string v1, string v2)
    {
        if (v1.Equals("BBOX_power"))
        {
            if (v2.Equals("power")) { return BBOX_Power_power_List; }
            if (v2.Equals("current")) { return BBOX_Power_current_List; }
            if (v2.Equals("voltage")) { return BBOX_Power_voltage_List; }
        }
        if (v1.Equals("BBOX_status"))
        {
            if (v2.Equals("SHD_IN")) { return BBOXStatus_SHD_IN_List; }
            if (v2.Equals("SHD_OUT")) { return BBOXStatus_SHD_OUT_List; }
            if (v2.Equals("TSMS")) { return BBOXStatus_TSMS_List; }
            if (v2.Equals("AIR_N")) { return BBOXStatus_AIR_N_List; }
            if (v2.Equals("AIR_P")) { return BBOXStatus_AIR_P_List; }
            if (v2.Equals("PRECH_60V")) { return BBOXStatus_PRECH_60V_List; }
            if (v2.Equals("IMD_OK")) { return BBOXStatus_IMD_OK_List; }
            if (v2.Equals("BMS_OK")) { return BBOXStatus_BMS_OK_List; }
            if (v2.Equals("SIGNAL_ERROR")) { return BBOXStatus_SIGNAL_ERROR_List; }
            if (v2.Equals("SHD_RESET")) { return BBOXStatus_SHD_RESET_List; }
            if (v2.Equals("SHD_EN")) { return BBOXStatus_SHD_EN_List; }
            if (v2.Equals("POLARITY")) { return BBOXStatus_POLARITY_List; }
            if (v2.Equals("FANS")) { return BBOXStatus_FANS_List; }
            if (v2.Equals("STM_temp")) { return BBOXStatus_STM_TEMP_List; }
        }
        if (v1.Equals("GPS_data"))
        {
            if (v2.Equals("latitude")) { return GPS_data_LATITUDE_List; }
            //if (v2.Equals("latitude_char")) { ViewGraph.Values[listIndex] = ViewGraph.BBOXStatus_STM_TEMP_List; } } }
            if (v2.Equals("longitude")) { return GPS_data_LONGTITUDE_List; }
            //if (v2.Equals("longitude_char")) { foreach (var msg in BBOXPowerList) { ViewGraph.Values[listIndex].Add(msg.BBOXPower.power); } }
            if (v2.Equals("speed")) { return GPS_data_SPEED_List; }
            if (v2.Equals("course")) { return GPS_data_COURSE_List; }
            if (v2.Equals("altitude")) { return GPS_data_ALTITUDE_List; }
        }
        if (v1.Equals("ECU_State"))
        {
            if (v2.Equals("ECU_Status")) { return ECU_State_ECU_STATE_List; }
            if (v2.Equals("FL_AMK_Status")) { return ECU_State_FL_AMK_STATUS_List; }
            if (v2.Equals("FR_AMK_Status")) { return ECU_State_FR_AMK_STATUS_List; }
            if (v2.Equals("RL_AMK_Status")) { return ECU_State_RL_AMK_STATUS_List; }
            if (v2.Equals("RR_AMK_Status")) { return ECU_State_RR_AMK_Status_List; }
            if (v2.Equals("TempMotor_H")) { return ECU_State_TempMotor_H_List; }
            if (v2.Equals("TempInverter_H")) { return ECU_State_TempInverter_H_List; }
            if (v2.Equals("TempIGBT_H")) { return ECU_State_TempIGBT_H_List; }
        }
        if (v1.Equals("BBOX_command"))
        {
            if (v2.Equals("FANS")) { return BBOX_Command_FANS_List; }
            if (v2.Equals("SHD_EN")) { return BBOX_Command_SHD_EN_List; }
        }
        if (v1.Equals("FU_Values_1"))
        {
            if (v2.Equals("apps1")) { return FU_Values_1_apps1_List; }
            if (v2.Equals("apps2")) { return FU_Values_1_apps2_List; }
            if (v2.Equals("brake1")) { return FU_Values_1_brake1_List; }
            if (v2.Equals("brake2")) { return FU_Values_1_brake2_List; }
            if (v2.Equals("error")) { return FU_Values_1_error_List; }
        }
        if (v1.Equals("Interconnect"))
        {
            if (v2.Equals("car_state")) { return Interconnect_car_state_List; }
            if (v2.Equals("left_w_pump")) { return Interconnect_left_w_pump_List; }
            if (v2.Equals("right_w_pump")) { return Interconnect_right_w_pump_List; }
            if (v2.Equals("brake_red")) { return Interconnect_brake_red_List; }
            if (v2.Equals("brake_white")) { return Interconnect_brake_white_List; }
            if (v2.Equals("tsas")) { return Interconnect_tsas_List; }
            if (v2.Equals("killswitch_R")) { return Interconnect_killswitch_R_List; }
            if (v2.Equals("reserve")) { return Interconnect_reserve_List; }
            if (v2.Equals("susp_RR")) { return Interconnect_susp_RR_List; }
            if (v2.Equals("susp_RL")) { return Interconnect_susp_RL_List; }
        }
        if (v1.Equals("FU_Values_2"))
        {
            if (v2.Equals("steer")) { return FU_Values_2_steer_List; }
            if (v2.Equals("susp_FL")) { return FU_Values_2_susp_FL_List; }
            if (v2.Equals("susp_FR")) { return FU_Values_2_susp_FR_List; }
            if (v2.Equals("brake_pos")) { return FU_Values_2_brake_pos_List; }
            if (v2.Equals("RTD")) { return FU_Values_2_RTD_List; }
            if (v2.Equals("BOTS")) { return FU_Values_2_BOTS_List; }
            if (v2.Equals("SHDB")) { return FU_Values_2_SHDB_List; }
            if (v2.Equals("INERTIA_SW")) { return FU_Values_2_INERTIA_SW_List; }
            if (v2.Equals("reserve")) { return FU_Values_2_reserve_List; }
        }
        if (v1.Equals("BMS_Command"))
        {
            if (v2.Equals("BMS_Balanc")) { return BMS_Command_BMS_Balanc_List; }
            if (v2.Equals("BMS_FullMode")) { return BMS_Command_BMS_FullMode_List; }
            if (v2.Equals("BMS_OK")) { return BMS_Command_BMS_OK_List; }
            if (v2.Equals("BMS_ONOFF")) { return BMS_Command_BMS_ONOFF_List; }
            if (v2.Equals("BMS_CAN")) { return BMS_Command_BMS_CAN_List; }
        }
        if (v1.Equals("BMS_State"))
        {
            if (v2.Equals("BMS_Mode")) { return BMS_State_BMS_Mode_List; }
            if (v2.Equals("BMS_Faults")) { return BMS_State_BMS_Faults_List; }
            if (v2.Equals("CellVolt_L")) { return BMS_State_CellVolt_L_List; }
            if (v2.Equals("CellVolt_H")) { return BMS_State_CellVolt_H_List; }
            if (v2.Equals("CellTemp_L")) { return BMS_State_CellTemp_L_List; }
            if (v2.Equals("CellTemp_H")) { return BMS_State_CellTemp_H_List; }
            if (v2.Equals("BMS_Ident")) { return BMS_State_BMS_Ident_List; }
        }
        if (v1.Equals("wheel_RPM"))
        {
            if (v2.Equals("front_right")) { return wheel_RPM_front_right_List; }
            if (v2.Equals("front_left")) { return wheel_RPM_front_left_List; }
            if (v2.Equals("rear_right")) { return wheel_RPM_rear_right_List; }
            if (v2.Equals("rear_left")) { return wheel_RPM_BMS_rear_left_List; }
        }
        if (v1.Equals("BMS_Voltages"))
        {
            if (v2.Equals("BMS_VoltIdent")) { return BMS_VoltIdent_BMS_VoltIdentt_List; }
            if (v2.Equals("BMS_Volt1")) { return BMS_VoltIdent_BMS_Volt1_List; }
            if (v2.Equals("BMS_Volt2")) { return BMS_VoltIdent_BMS_Volt2_List; }
            if (v2.Equals("BMS_Volt3")) { return BMS_VoltIdent_BMS_Volt3_List; }
            if (v2.Equals("BMS_Volt4")) { return BMS_VoltIdent_BMS_Volt4_List; }
            if (v2.Equals("BMS_Volt5")) { return BMS_VoltIdent_BMS_Volt5_List; }
            if (v2.Equals("BMS_Volt6")) { return BMS_VoltIdent_BMS_Volt6_List; }
            if (v2.Equals("BMS_Volt7")) { return BMS_VoltIdent_BMS_Volt7_List; }
        }
        if (v1.Equals("BMS_Temps"))
        {
            if (v2.Equals("BMS_TempIdent")) { return BMS_Temps_BMS_TempIdent_List; }
            if (v2.Equals("BMS_Temp1")) { return BMS_Temps_BMS_Temp1_List; }
            if (v2.Equals("BMS_Temp2")) { return BMS_Temps_BMS_Temp2_List; }
            if (v2.Equals("BMS_Temp3")) { return BMS_Temps_BMS_Temp3_List; }
            if (v2.Equals("BMS_Temp4")) { return BMS_Temps_BMS_Temp4_List; }
            if (v2.Equals("BMS_Temp5")) { return BMS_Temps_BMS_Temp5_List; }
            if (v2.Equals("BMS_Temp6")) { return BMS_Temps_BMS_Temp6_List; }
            if (v2.Equals("BMS_Temp7")) { return BMS_Temps_BMS_Temp7_List; }
        }
        return null;
    }

        internal void addBBOXPower(Msg msg)
        {
            BBOX_Power_power_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXPower.power));
            BBOX_Power_current_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXPower.current));
            BBOX_Power_voltage_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXPower.voltage)); 
        }
        internal void addBBOXStatus(Msg msg)
        {
            BBOXStatus_SHD_IN_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.SHD_IN));
            BBOXStatus_SHD_OUT_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.SHD_OUT));
            BBOXStatus_TSMS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.TSMS));
            BBOXStatus_AIR_N_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.AIR_N));
            BBOXStatus_AIR_P_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.AIR_P));
            BBOXStatus_PRECH_60V_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.PRECH_60V));
            BBOXStatus_IMD_OK_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.IMD_OK));
            BBOXStatus_BMS_OK_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.BMS_OK));
            BBOXStatus_SIGNAL_ERROR_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.SIGNAL_ERROR));
            BBOXStatus_SHD_RESET_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.SHD_RESET));
            BBOXStatus_SHD_EN_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.SHD_EN));
            BBOXStatus_POLARITY_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.POLARITY));
            BBOXStatus_FANS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.FANS));
            BBOXStatus_STM_TEMP_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXStatus.STM_temp));
        }
        internal void addGPSData(Msg msg)
        {
            GPS_data_LATITUDE_List.Add(new DateTimePoint(msg.ReceiptTime, msg.GPSData.latitude));
            GPS_data_LONGTITUDE_List.Add(new DateTimePoint(msg.ReceiptTime, msg.GPSData.longitude));
            GPS_data_SPEED_List.Add(new DateTimePoint(msg.ReceiptTime, msg.GPSData.speed));
            GPS_data_COURSE_List.Add(new DateTimePoint(msg.ReceiptTime, msg.GPSData.course));
            GPS_data_ALTITUDE_List.Add(new DateTimePoint(msg.ReceiptTime, msg.GPSData.altitude));
        }
        internal void addECUState(Msg msg)
        {
            ECU_State_ECU_STATE_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.ECU_Status));
            ECU_State_FL_AMK_STATUS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.FL_AMK_Status));
            ECU_State_FR_AMK_STATUS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.FR_AMK_Status));
            ECU_State_RL_AMK_STATUS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.RL_AMK_Status));
            ECU_State_RR_AMK_Status_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.RR_AMK_Status));
            ECU_State_TempMotor_H_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.TempMotor_H));
            ECU_State_TempInverter_H_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.TempInverter_H));
            ECU_State_TempIGBT_H_List.Add(new DateTimePoint(msg.ReceiptTime, msg.ECUState.TempIGBT_H));
        }
        internal void addBBOXCommand(Msg msg)
        {
            BBOX_Command_FANS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXCommand.FANS));
            BBOX_Command_SHD_EN_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BBOXCommand.SHD_EN));
        }
        internal void addFuValues1(Msg msg)
        {
            FU_Values_1_apps1_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues1.apps1));
            FU_Values_1_apps2_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues1.apps2));
            FU_Values_1_brake1_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues1.brake1));
            FU_Values_1_brake2_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues1.brake2));
            FU_Values_1_error_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues1.error));
        }
        internal void addInterconnect(Msg msg)
        {
            Interconnect_car_state_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.car_state));
            Interconnect_left_w_pump_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.left_w_pump));
            Interconnect_right_w_pump_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.right_w_pump));
            Interconnect_brake_red_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.brake_red));
            Interconnect_brake_white_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.brake_white));
            Interconnect_tsas_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.tsas));
            Interconnect_killswitch_R_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.killswitch_R));
            Interconnect_reserve_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.reserve));
            Interconnect_susp_RR_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.susp_RR));
            Interconnect_susp_RL_List.Add(new DateTimePoint(msg.ReceiptTime, msg.Interconnect.susp_RL));
        }
        internal void addFuValues2(Msg msg)
        {
            FU_Values_2_steer_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.steer));
            FU_Values_2_susp_FL_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.susp_FL));
            FU_Values_2_susp_FR_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.susp_FR));
            FU_Values_2_brake_pos_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.brake_pos));
            FU_Values_2_RTD_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.RTD));
            FU_Values_2_BOTS_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.BOTS));
            FU_Values_2_SHDB_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.SHDB));
            FU_Values_2_INERTIA_SW_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.INERTIA_SW));
            FU_Values_2_reserve_List.Add(new DateTimePoint(msg.ReceiptTime, msg.FUValues2.reserve));
        }
        internal void addBMSCommand(Msg msg)
        {
            BMS_Command_BMS_Balanc_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSCommand.BMS_Balanc));
            BMS_Command_BMS_FullMode_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSCommand.BMS_FullMode));
            BMS_Command_BMS_OK_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSCommand.BMS_OK));
            BMS_Command_BMS_ONOFF_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSCommand.BMS_ONOFF));
            BMS_Command_BMS_CAN_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSCommand.BMS_CAN));
        }
        internal void addBMSState(Msg msg)
        {
            BMS_State_BMS_Mode_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.BMS_Mode));
            BMS_State_BMS_Faults_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.BMS_Faults));
            BMS_State_CellVolt_L_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.CellVolt_L));
            BMS_State_CellVolt_H_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.CellVolt_H));
            BMS_State_CellTemp_L_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.CellTemp_L));
            BMS_State_CellTemp_H_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.CellTemp_H));
            BMS_State_BMS_Ident_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSState.BMS_Ident));
        }
        internal void addWheelRPM(Msg msg)
        {
            wheel_RPM_front_right_List.Add(new DateTimePoint(msg.ReceiptTime, msg.WheelRPM.front_right));
            wheel_RPM_front_left_List.Add(new DateTimePoint(msg.ReceiptTime, msg.WheelRPM.front_left));
            wheel_RPM_rear_right_List.Add(new DateTimePoint(msg.ReceiptTime, msg.WheelRPM.rear_right));
            wheel_RPM_BMS_rear_left_List.Add(new DateTimePoint(msg.ReceiptTime, msg.WheelRPM.rear_left));
        }
        internal void addBMSVoltages(Msg msg)
        {
            BMS_VoltIdent_BMS_VoltIdentt_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_VoltIdent));
            BMS_VoltIdent_BMS_Volt1_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt1));
            BMS_VoltIdent_BMS_Volt2_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt2));
            BMS_VoltIdent_BMS_Volt3_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt3));
            BMS_VoltIdent_BMS_Volt4_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt4));
            BMS_VoltIdent_BMS_Volt5_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt5));
            BMS_VoltIdent_BMS_Volt6_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt6));
            BMS_VoltIdent_BMS_Volt7_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSVoltages.BMS_Volt7));
        }
        internal void addBMSTemps(Msg msg)
        {
            BMS_Temps_BMS_TempIdent_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_TempIdent));
            BMS_Temps_BMS_Temp1_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp1));
            BMS_Temps_BMS_Temp2_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp2));
            BMS_Temps_BMS_Temp3_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp3));
            BMS_Temps_BMS_Temp4_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp4));
            BMS_Temps_BMS_Temp5_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp5));
            BMS_Temps_BMS_Temp6_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp6));
            BMS_Temps_BMS_Temp7_List.Add(new DateTimePoint(msg.ReceiptTime, msg.BMSTemps.BMS_Temp7));
        }
        internal void clearLists()
    {
            SeriesCollection.Clear();
    }
}}


