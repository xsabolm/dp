using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection
{
    public class DatabaseQueries
    {
        public static String DATABASE_FILENAME = "\\stubaGreenTeamDataBase.sdf";

        public static String ID = "ID";
        public static String START_TIME = "start_time";
        public static String COMMENT = "comment";
        public static String LOCALITY = "locality";
        public static String ID_MENSURATION = "ID_mensuration";
        public static String ID_DISCIPLINE = "ID_discipline";
        public static String ID_RUN = "Id_run";
        public static String NAME = "name";
        public static String FINISH_TIME = "finish_time";
        public static String RECEIPT_TIME = "receipt_time";
        public static String RUN_NUMBER = "run_number";

        public static String SELECT_ALL_MENSURATION = "SELECT * FROM mensuration;";
        public static String SELECT_ALL_DISCIPLINE = "SELECT * FROM discipline ;";
        public static String SELECT_ALL_RUNS = "SELECT * FROM run;";
        public static String SELECT_ALL_MSGS = "SELECT * FROM msg;";

        public static String INSERT_MENSURATION = "INSERT INTO mensuration (start_time, comment, locality) VALUES (@start_time, @comment, @locality);";
        public static String INSERT_DISCIPLINE = "INSERT INTO discipline (ID_mensuration, comment, name) VALUES (@ID_mensuration, @comment, @name);";
        public static String INSERT_RUN = "INSERT INTO run (ID_discipline, start_time, finish_time, comment, run_number) VALUES (@ID_discipline, @start_time, @finish_time, @comment, @run_number);";
        public static String INSERT_MSG = "INSERT INTO msg (ID_run,receipt_time,power,current_,voltage,SHD_IN,SHD_OUT,TSMS,AIR_N,AIR_P,PRECH_60V,IMD_OK,BBOXStatus_BMS_OK,SIGNAL_ERROR,SHD_RESET,BBOXStatus_SHD_EN,POLARITY,BBOXStatus_FANS,STM_temp,latitude,latitude_char,longitude,longitude_char,speed,course,altitude,ECU_Status,FL_AMK_Status,FR_AMK_Status,RL_AMK_Status,RR_AMK_Status,TempMotor_H,TempInverter_H,TempIGBT_H,BBOXCommand_FANS,BBOXCommand_SHD_EN,apps1,apps2,brake1,brake2,error,car_state,left_w_pump,right_w_pump,brake_red,brake_white,tsas,killswitch_R,killswitch_L,Interconnect_reserve,susp_RR,susp_RL,steer,susp_FL,susp_FR,brake_pos,RTD,BOTS,SHDB,INERTIA_SW,FUValues2_reserve,BMS_Balanc,BMS_FullMode,BMSCommand_BMS_OK,BMS_ONOFF,BMS_CAN,BMS_Mode,BMS_Faults,CellVolt_L,CellVolt_H,CellTemp_L,CellTemp_H,BMS_Ident,front_right,front_left,rear_right,rear_left,BMS_VoltIdent,BMS_Volt1,BMS_Volt2,BMS_Volt3,BMS_Volt4,BMS_Volt5,BMS_Volt6,BMS_Volt7,BMS_TempIdent,BMS_Temp1,BMS_Temp2,BMS_Temp3,BMS_Temp4,BMS_Temp5,BMS_Temp6,BMS_Temp7) VALUES (@ID_run, @receipt_time, @power, @current_, @voltage, @SHD_IN, @SHD_OUT, @TSMS, @AIR_N, @AIR_P, @PRECH_60V, @IMD_OK, @BBOXStatus_BMS_OK, @SIGNAL_ERROR, @SHD_RESET, @BBOXStatus_SHD_EN, @POLARITY, @BBOXStatus_FANS, @STM_temp, @latitude, @latitude_char, @longitude, @longitude_char, @speed, @course, @altitude, @ECU_Status, @FL_AMK_Status, @FR_AMK_Status, @RL_AMK_Status, @RR_AMK_Status, @TempMotor_H, @TempInverter_H, @TempIGBT_H, @BBOXCommand_FANS, @BBOXCommand_SHD_EN, @apps1, @apps2, @brake1, @brake2, @error, @car_state, @left_w_pump, @right_w_pump, @brake_red, @brake_white, @tsas, @killswitch_R, @killswitch_L, @Interconnect_reserve, @susp_RR, @susp_RL, @steer, @susp_FL, @susp_FR, @brake_pos, @RTD, @BOTS, @SHDB, @INERTIA_SW, @FUValues2_reserve, @BMS_Balanc, @BMS_FullMode, @BMSCommand_BMS_OK, @BMS_ONOFF, @BMS_CAN, @BMS_Mode, @BMS_Faults, @CellVolt_L, @CellVolt_H, @CellTemp_L, @CellTemp_H, @BMS_Ident, @front_right, @front_left, @rear_right, @rear_left, @BMS_VoltIdent, @BMS_Volt1, @BMS_Volt2, @BMS_Volt3, @BMS_Volt4, @BMS_Volt5, @BMS_Volt6, @BMS_Volt7, @BMS_TempIdent, @BMS_Temp1, @BMS_Temp2, @BMS_Temp3, @BMS_Temp4, @BMS_Temp5, @BMS_Temp6, @BMS_Temp7);";

        public static String INSERT_BASIC_MSG = "INSERT INTO msg (ID_run,receipt_time) VALUES (@ID_run, @receipt_time);";

        public static String UPDATE_MSG_BBOX_power = "UPDATE msg SET power = @power, current_ = @current_, voltage = @voltage WHERE ID = @ID;";
        public static String UPDATE_MSG_BBOX_status = "UPDATE msg SET SHD_IN = @SHD_IN, SHD_OUT  = @SHD_OUT ,TSMS  = @TSMS, AIR_N  = @AIR_N, AIR_P  = @AIR_P, PRECH_60V  = @PRECH_60V, IMD_OK = @IMD_OK, BBOXStatus_BMS_OK  = @BBOXStatus_BMS_OK, SIGNAL_ERROR  = @SIGNAL_ERROR, SHD_RESET = @SHD_RESET, BBOXStatus_SHD_EN  = @BBOXStatus_SHD_EN, POLARITY  = @POLARITY, BBOXStatus_FANS  = @BBOXStatus_FANS, STM_temp  = @STM_temp WHERE ID = @ID;";
        public static String UPDATE_MSG_GPS_data = "UPDATE msg SET latitude = @latitude ,latitude_char = @latitude_char ,longitude = @longitude ,longitude_char = @longitude_char ,speed = @speed ,course = @course ,altitude = @altitude WHERE ID = @ID;";
        public static String UPDATE_MSG_ECU_State = "UPDATE msg SET ECU_Status = @ECU_Status ,FL_AMK_Status = @FL_AMK_Status ,FR_AMK_Status = @FR_AMK_Status ,RL_AMK_Status = @RL_AMK_Status ,RR_AMK_Status = @RR_AMK_Status ,TempMotor_H = @TempMotor_H ,TempInverter_H = @TempInverter_H ,TempIGBT_H = @TempIGBT_H WHERE ID = @ID;";
        public static String UPDATE_MSG_BBOX_command = "UPDATE msg SET BBOXCommand_FANS = @BBOXCommand_FANS, BBOXCommand_SHD_EN = @BBOXCommand_SHD_EN WHERE ID = @ID;";
        public static String UPDATE_MSG_FU_Values_1 = "UPDATE msg SET apps1 = @apps1 ,apps2 = @apps2 ,brake1 = @brake1 ,brake2 = @brake2 ,error = @error  WHERE ID = @ID;";
        public static String UPDATE_MSG_Interconnect = "UPDATE msg SET car_state = @car_state ,left_w_pump = @left_w_pump ,right_w_pump = @right_w_pump ,brake_red = @brake_red ,brake_white = @brake_white ,tsas = @tsas ,killswitch_R = @killswitch_R ,killswitch_L = @killswitch_L ,Interconnect_reserve = @Interconnect_reserve ,susp_RR = @susp_RR ,susp_RL = @susp_RL WHERE ID = @ID;";
        public static String UPDATE_MSG_FU_Values_2 = "UPDATE msg SET steer = @steer ,susp_FL = @susp_FL ,susp_FR = @susp_FR ,brake_pos = @brake_pos ,RTD = @RTD ,BOTS = @BOTS ,SHDB = @SHDB ,INERTIA_SW = @INERTIA_SW ,FUValues2_reserve = @FUValues2_reserve WHERE ID = @ID;";
        public static String UPDATE_MSG_BMS_Command = "UPDATE msg SET BMS_Balanc = @BMS_Balanc ,BMS_FullMode = @BMS_FullMode ,BMSCommand_BMS_OK = @BMSCommand_BMS_OK ,BMS_ONOFF = @BMS_ONOFF ,BMS_CAN = @BMS_CAN WHERE ID = @ID;";
        public static String UPDATE_MSG_BMS_State = "UPDATE msg SET BMS_Mode = @BMS_Mode ,BMS_Faults = @BMS_Faults ,CellVolt_L = @CellVolt_L ,CellVolt_H = @CellVolt_H ,CellTemp_L = @CellTemp_L ,CellTemp_H = @CellTemp_H ,BMS_Ident = @BMS_Ident WHERE ID = @ID;";
        public static String UPDATE_MSG_Wheel_RPM = "UPDATE msg SET front_right = @front_right ,front_left = @front_left ,rear_right = @rear_right ,rear_left = @rear_left WHERE ID = @ID;";
        public static String UPDATE_MSG_BMS_Voltages = "UPDATE msg SET BMS_VoltIdent = @BMS_VoltIdent ,BMS_Volt1 = @BMS_Volt1 ,BMS_Volt2 = @BMS_Volt2 ,BMS_Volt3 = @BMS_Volt3 ,BMS_Volt4 = @BMS_Volt4 ,BMS_Volt5 = @BMS_Volt5 ,BMS_Volt6 = @BMS_Volt6 ,BMS_Volt7 = @BMS_Volt7 WHERE ID = @ID;";
        public static String UPDATE_MSG_BMS_Temps = "UPDATE msg SET BMS_TempIdent = @BMS_TempIdent ,BMS_Temp1 = @BMS_Temp1 ,BMS_Temp2 = @BMS_Temp2 ,BMS_Temp3 = @BMS_Temp3 ,BMS_Temp4 = @BMS_Temp4 ,BMS_Temp5 = @BMS_Temp5 ,BMS_Temp6 = @BMS_Temp6 ,BMS_Temp7 = @BMS_Temp7 WHERE ID = @ID;";

        public static String LAST_ID = "SELECT @@IDENTITY AS ID;";

        internal static String selectMsgByDisciplineId(int idDiscipline)
        {
            return "SELECT * FROM msg where ID_disciplina=" + idDiscipline + ";";
        }
        
        internal static String selectMensurationById(int idMesuration)
        {
            return "SELECT * FROM mensuration where ID=" + idMesuration + ";";
        }

        internal static String selectRunByDisciplineId(int idDiscipline)
        {
            return "SELECT * FROM run where ID_discipline=" + idDiscipline + ";";
        }


        internal static String selectDisciplineByMensurationId(int idMensuration)
        {
            return "SELECT * FROM discipline where Id_mensuration=" + idMensuration + ";";
        }

        internal static String selectMsgByMensurationId(int idMensuration)
        {
            return "SELECT msg.ID, msg.ID_discipline, msg.ID_run, msg.receipt_time FROM msg inner JOIN discipline ON msg.ID_discipline=discipline.ID where discipline.ID_mensuration = " + idMensuration + ";";
        }

        internal static string selectMsgByRunId(int idRun)
        {
            return "SELECT * FROM msg where ID_run=" + idRun + ";";
        }

        public static String receipt_time = "receipt_time";
        public static String power = "power";
        public static String current_ = "current_";
        public static String voltage = "voltage";
        public static String SHD_IN = "SHD_IN";
        public static String SHD_OUT = "SHD_OUT";
        public static String TSMS = "TSMS";
        public static String AIR_N = "AIR_N";
        public static String AIR_P = "AIR_P";
        public static String PRECH_60V = "PRECH_60V";
        public static String IMD_OK = "IMD_OK";
        public static String BBOXStatus_BMS_OK = "BBOXStatus_BMS_OK";
        public static String SIGNAL_ERROR = "SIGNAL_ERROR";
        public static String SHD_RESET = "SHD_RESET";
        public static String BBOXStatus_SHD_EN = "BBOXStatus_SHD_EN";
        public static String POLARITY = "POLARITY";
        public static String BBOXStatus_FANS = "BBOXStatus_FANS";
        public static String STM_temp = "STM_temp";
        public static String latitude = "latitude";
        public static String latitude_char = "latitude_char";
        public static String longitude = "longitude";
        public static String longitude_char = "longitude_char";
        public static String speed = "speed";
        public static String course = "course";
        public static String altitude = "altitude";
        public static String ECU_Status = "ECU_Status";
        public static String FL_AMK_Status = "FL_AMK_Status";
        public static String FR_AMK_Status = "FR_AMK_Status";
        public static String RL_AMK_Status = "RL_AMK_Status";
        public static String RR_AMK_Status = "RR_AMK_Status";
        public static String TempMotor_H = "TempMotor_H";
        public static String TempInverter_H = "TempInverter_H";
        public static String TempIGBT_H = "TempIGBT_H";
        public static String BBOXCommand_FANS = "BBOXCommand_FANS";
        public static String BBOXCommand_SHD_EN = "BBOXCommand_SHD_EN";
        public static String apps1 = "apps1";
        public static String apps2 = "apps2";
        public static String brake1 = "brake1";
        public static String brake2 = "brake2";
        public static String error = "error";
        public static String car_state = "car_state";
        public static String left_w_pump = "left_w_pump";
        public static String right_w_pump = "right_w_pump";
        public static String brake_red = "brake_red";
        public static String brake_white = "brake_white";
        public static String tsas = "tsas";
        public static String killswitch_R = "killswitch_R";
        public static String killswitch_L = "killswitch_L";
        public static String Interconnect_reserve = "Interconnect_reserve";
        public static String susp_RR = "susp_RR";
        public static String susp_RL = "susp_RL";
        public static String steer = "steer";
        public static String susp_FL = "susp_FL";
        public static String susp_FR = "susp_FR";
        public static String brake_pos = "brake_pos";
        public static String RTD = "RTD";
        public static String BOTS = "BOTS";
        public static String SHDB = "SHDB";
        public static String INERTIA_SW = "INERTIA_SW";
        public static String FUValues2_reserve = "FUValues2_reserve";
        public static String BMS_Balanc = "BMS_Balanc";
        public static String BMS_FullMode = "BMS_FullMode";
        public static String BMSCommand_BMS_OK = "BMSCommand_BMS_OK";
        public static String BMS_ONOFF = "BMS_ONOFF";
        public static String BMS_CAN = "BMS_CAN";
        public static String BMS_Mode = "BMS_Mode";
        public static String BMS_Faults = "BMS_Faults";
        public static String CellVolt_L = "CellVolt_L";
        public static String CellVolt_H = "CellVolt_H";
        public static String CellTemp_L = "CellTemp_L";
        public static String CellTemp_H = "CellTemp_H";
        public static String BMS_Ident = "BMS_Ident";
        public static String front_right = "front_right";
        public static String front_left = "front_left";
        public static String rear_right = "rear_right";
        public static String rear_left = "rear_left";
        public static String BMS_VoltIdent = "BMS_VoltIdent";
        public static String BMS_Volt1 = "BMS_Volt1";
        public static String BMS_Volt2 = "BMS_Volt2";
        public static String BMS_Volt3 = "BMS_Volt3";
        public static String BMS_Volt4 = "BMS_Volt4";
        public static String BMS_Volt5 = "BMS_Volt5";
        public static String BMS_Volt6 = "BMS_Volt6";
        public static String BMS_Volt7 = "BMS_Volt7";
        public static String BMS_TempIdent = "BMS_TempIdent";
        public static String BMS_Temp1 = "BMS_Temp1";
        public static String BMS_Temp2 = "BMS_Temp2";
        public static String BMS_Temp3 = "BMS_Temp3";
        public static String BMS_Temp4 = "BMS_Temp4";
        public static String BMS_Temp5 = "BMS_Temp5";
        public static String BMS_Temp6 = "BMS_Temp6";
        public static String BMS_Temp7 = "BMS_Temp7";


    }
}
