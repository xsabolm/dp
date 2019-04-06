using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using DP_WpfApp;
using connection;

namespace connection
{
    public static class DataBaseServices
    {


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static SqlCeConnection dbConnection;

        static public void openConnection()
        {
            try
            {
                dbConnection = new SqlCeConnection(getConnestionString());
                dbConnection.Open();
                log.Info("Connected to database, databse path: " + getConnestionString());

            }
            catch (Exception e)
            {
                log.Error("Error during connecting to database" + e.ToString());
                MessageBox.Show("Error - during connecting to database");
            }
        }

        static public DataTable selectFromDatabase(String selectQuerry)
        {
            DataTable table = new DataTable();
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            log.Info(selectQuerry);
            using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(selectQuerry, dbConnection))
            {
                adapter.Fill(table);
            }
            dbConnection.Close();
            return table;
        }

        static void closeConnection()
        {
            dbConnection.Close();
            log.Info("Close connection with database");
        }

        static String getConnestionString()
        {
            return @"Data Source=" + System.Environment.CurrentDirectory + DatabaseQueries.DATABASE_FILENAME + ";Max Database Size=2048";
        }

        internal static int insertMensuration(Mensuration mensuration)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            int ID = 0;
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.INSERT_MENSURATION, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.START_TIME, mensuration.StartTime);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.COMMENT, mensuration.Comment);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.LOCALITY, mensuration.Locality);

            try { cmd.ExecuteNonQuery();  log.Info("Inserting mensuration"); } catch (Exception e) { log.Error("Error during inserting mensuration to database:  " + e.ToString()); }

            cmd.CommandText = DatabaseQueries.LAST_ID;
            ID = Convert.ToInt32((cmd.ExecuteScalar()));
            log.Info("GET ID:" + ID);

            dbConnection.Close();
            return ID;
        }

        internal static void insertModel(Mensuration mensuration)
        {
            mensuration.ID = insertMensuration(mensuration);
            mensuration.WasSaved = true;
            mensuration.ListDiscipline.ForEach(discipline => insertDiscipline(discipline, mensuration.ID));
        }

        private static void insertDiscipline(Discipline discipline, int ID_mensuration)
        {
            if (!discipline.WasSaved)
            {
                dbConnection = new SqlCeConnection(getConnestionString());
                dbConnection.Open();
                int ID_disciplina = 0;
                SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.INSERT_DISCIPLINE, dbConnection);

                cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID_MENSURATION, ID_mensuration);
                cmd.Parameters.AddWithValue("@" + DatabaseQueries.COMMENT, discipline.Comment);
                cmd.Parameters.AddWithValue("@" + DatabaseQueries.NAME, discipline.Name);

                try { cmd.ExecuteNonQuery(); log.Info("Inserting discipline"); } catch (Exception e) { log.Error("Error during inserting discipline to database:  " + e.ToString()); }

                cmd.CommandText = DatabaseQueries.LAST_ID;
                ID_disciplina = Convert.ToInt32((cmd.ExecuteScalar()));
                log.Info("GET ID:" + ID_disciplina);
                dbConnection.Close();

                discipline.WasSaved = true;
                discipline.ListRuns.ForEach(run => insertRuns(run, ID_disciplina));
            }
        }

        private static void insertRuns(Run run, int ID_disciplina)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            int ID_run = 0;
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.INSERT_RUN, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID_DISCIPLINE, ID_disciplina);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.START_TIME, run.StartTime);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.FINISH_TIME, run.FinishTime);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.COMMENT, run.Comment);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.RUN_NUMBER, run.RunNumber);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting run"); } catch (Exception e) { log.Error("Error during inserting run to database:  " + e.ToString()); }

            cmd.CommandText = DatabaseQueries.LAST_ID;
            ID_run = Convert.ToInt32((cmd.ExecuteScalar()));
            log.Info("GET ID:" + ID_run);
            dbConnection.Close();

            run.ListMsg.ForEach(msg => insertMsg(msg, ID_run));
        }

        private static void insertMsg(Msg msg, int ID_run)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            int ID = 0;
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.INSERT_BASIC_MSG, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID_RUN, ID_run);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.receipt_time, msg.ReceiptTime);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting basic msg"); } catch (Exception e) { log.Error("Error during inserting basic msg to database:  " + e.ToString()); }

            cmd.CommandText = DatabaseQueries.LAST_ID;
            ID = Convert.ToInt32((cmd.ExecuteScalar()));
            dbConnection.Close();

            if(msg.JsonMsg.Data[0].BBOX_power != null){ updateMsgPartBBOX_power(msg.JsonMsg.Data[0].BBOX_power, ID); }
            if (msg.JsonMsg.Data[0].BBOX_status != null) { updateMsgPartBBOX_status(msg.JsonMsg.Data[0].BBOX_status, ID); }
            if (msg.JsonMsg.Data[0].GPS_data != null) { updateMsgPartGPS_data(msg.JsonMsg.Data[0].GPS_data, ID); }
            if (msg.JsonMsg.Data[0].ECU_State != null) { updateMsgPartECU_State(msg.JsonMsg.Data[0].ECU_State, ID); }
            if (msg.JsonMsg.Data[0].BBOX_command != null) { updateMsgPartBBOX_command(msg.JsonMsg.Data[0].BBOX_command, ID); }
            if (msg.JsonMsg.Data[0].FU_Values_1 != null) { updateMsgPartFU_Values_1(msg.JsonMsg.Data[0].FU_Values_1, ID); }
            if (msg.JsonMsg.Data[0].Interconnect != null) { updateMsgPartInterconnect(msg.JsonMsg.Data[0].Interconnect, ID); }
            if (msg.JsonMsg.Data[0].FU_Values_2 != null) { updateMsgPartFU_Values_2(msg.JsonMsg.Data[0].FU_Values_2, ID); }
            if (msg.JsonMsg.Data[0].BMS_Command != null) { updateMsgPartBMS_Command(msg.JsonMsg.Data[0].BMS_Command, ID); }
            if (msg.JsonMsg.Data[0].BMS_State != null) { updateMsgPartBMS_State(msg.JsonMsg.Data[0].BMS_State, ID); }
            if (msg.JsonMsg.Data[0].wheel_RPM != null) { updateMsgPartWheel_RPM(msg.JsonMsg.Data[0].wheel_RPM, ID); }
            if (msg.JsonMsg.Data[0].BMS_Voltages != null) { updateMsgPartBMS_Voltages(msg.JsonMsg.Data[0].BMS_Voltages, ID); }
            if (msg.JsonMsg.Data[0].BMS_Temps != null) { updateMsgPartBMS_Temps(msg.JsonMsg.Data[0].BMS_Temps, ID); }
        }

        private static void updateMsgPartBBOX_power(BBOXPower BBOXPower, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BBOX_power, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.power, BBOXPower.power);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.current_, BBOXPower.current);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.voltage, BBOXPower.voltage);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting BBOXPower"); } catch (Exception e) { log.Error("Error during inserting BBOXPower to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartBBOX_status(BBOXStatus BBOX_status, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BBOX_status, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.SHD_IN, BBOX_status.SHD_IN);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.SHD_OUT, BBOX_status.SHD_OUT);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.TSMS, BBOX_status.TSMS);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.AIR_N, BBOX_status.AIR_N);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.AIR_P, BBOX_status.AIR_P);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.PRECH_60V, BBOX_status.PRECH_60V);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.IMD_OK, BBOX_status.IMD_OK);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BBOXStatus_BMS_OK, BBOX_status.BMS_OK);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.SIGNAL_ERROR, BBOX_status.SIGNAL_ERROR);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.SHD_RESET, BBOX_status.SHD_RESET);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BBOXStatus_SHD_EN, BBOX_status.SHD_EN);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.POLARITY, BBOX_status.POLARITY);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BBOXStatus_FANS, BBOX_status.FANS);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.STM_temp, BBOX_status.STM_temp);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);


            try { cmd.ExecuteNonQuery(); log.Info("Inserting BBOX_status"); } catch (Exception e) { log.Error("Error during inserting BBOX_status to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartGPS_data(GPSData GPS_data, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_GPS_data, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.latitude, GPS_data.latitude);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.latitude_char, GPS_data.latitude_char);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.longitude, GPS_data.longitude);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.longitude_char, GPS_data.longitude_char);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.speed, GPS_data.speed);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.course, GPS_data.course);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.altitude, GPS_data.altitude);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);


            try { cmd.ExecuteNonQuery(); log.Info("Inserting GPS_data"); } catch (Exception e) { log.Error("Error during inserting GPS_data to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartECU_State(ECUState ECU_State, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_ECU_State, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ECU_Status, ECU_State.ECU_Status);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.FL_AMK_Status, ECU_State.FL_AMK_Status);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.FR_AMK_Status, ECU_State.FR_AMK_Status);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.RL_AMK_Status, ECU_State.RL_AMK_Status);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.RR_AMK_Status, ECU_State.RR_AMK_Status);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.TempMotor_H, ECU_State.TempMotor_H);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.TempInverter_H, ECU_State.TempInverter_H);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.TempIGBT_H, ECU_State.TempIGBT_H);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting ECU_State"); } catch (Exception e) { log.Error("Error during inserting ECU_State to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartBBOX_command(BBOXCommand BBOX_command, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BBOX_command, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BBOXCommand_FANS, BBOX_command.FANS);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BBOXCommand_SHD_EN, BBOX_command.SHD_EN);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting BBOX_command"); } catch (Exception e) { log.Error("Error during inserting BBOX_command to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartFU_Values_1(FUValues1 FU_Values_1, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_FU_Values_1, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.apps1, FU_Values_1.apps1);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.apps2, FU_Values_1.apps2);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.brake1, FU_Values_1.brake1);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.brake2, FU_Values_1.brake2);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.error, FU_Values_1.error);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting FU_Values_1"); } catch (Exception e) { log.Error("Error during inserting FU_Values_1 to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartInterconnect(Interconnect Interconnect, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_Interconnect, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.car_state, Interconnect.car_state);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.left_w_pump, Interconnect.left_w_pump);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.right_w_pump, Interconnect.right_w_pump);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.brake_red, Interconnect.brake_red);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.brake_white, Interconnect.brake_white);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.tsas, Interconnect.tsas);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.killswitch_R, Interconnect.killswitch_R);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.killswitch_L, Interconnect.killswitch_L);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.Interconnect_reserve, Interconnect.reserve);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.susp_RR, Interconnect.susp_RR);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.susp_RL, Interconnect.susp_RL);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting Interconnect"); } catch (Exception e) { log.Error("Error during inserting Interconnect to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartFU_Values_2(FUValues2 FU_Values_2, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_FU_Values_2, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.steer, FU_Values_2.steer);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.susp_FL, FU_Values_2.susp_FL);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.susp_FR, FU_Values_2.susp_FR);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.brake_pos, FU_Values_2.brake_pos);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.RTD, FU_Values_2.RTD);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BOTS, FU_Values_2.BOTS);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.SHDB, FU_Values_2.SHDB);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.INERTIA_SW, FU_Values_2.INERTIA_SW);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.FUValues2_reserve, FU_Values_2.reserve);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting FU_Values_2"); } catch (Exception e) { log.Error("Error during inserting FU_Values_2 to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartBMS_Command(BMSCommand BMS_Command, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BMS_Command, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Balanc, BMS_Command.BMS_Balanc);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_FullMode, BMS_Command.BMS_FullMode);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMSCommand_BMS_OK, BMS_Command.BMS_OK);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_ONOFF, BMS_Command.BMS_ONOFF);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_CAN, BMS_Command.BMS_CAN);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting BMS_Command"); } catch (Exception e) { log.Error("Error during inserting BMS_Command to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartBMS_State(BMSState BMS_State, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BMS_State, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Mode, BMS_State.BMS_Mode);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Faults, BMS_State.BMS_Faults);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.CellVolt_L, BMS_State.CellVolt_L);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.CellVolt_H, BMS_State.CellVolt_H);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.CellTemp_L, BMS_State.CellTemp_L);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.CellTemp_H, BMS_State.CellTemp_H);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Ident, BMS_State.BMS_Ident);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting BMS_State"); } catch (Exception e) { log.Error("Error during inserting BMS_State to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartWheel_RPM(WheelRPM wheel_RPM, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_Wheel_RPM, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.front_right, wheel_RPM.front_right);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.front_left, wheel_RPM.front_left);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.rear_right, wheel_RPM.rear_right);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.rear_left, wheel_RPM.rear_left);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting wheel_RPM"); } catch (Exception e) { log.Error("Error during inserting wheel_RPM to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartBMS_Voltages(BMSVoltages BMS_Voltages, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BMS_Voltages, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_VoltIdent, BMS_Voltages.BMS_VoltIdent);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt1, BMS_Voltages.BMS_Volt1);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt2, BMS_Voltages.BMS_Volt2);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt3, BMS_Voltages.BMS_Volt3);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt4, BMS_Voltages.BMS_Volt4);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt5, BMS_Voltages.BMS_Volt5);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt6, BMS_Voltages.BMS_Volt6);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Volt7, BMS_Voltages.BMS_Volt7);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting BMS_Voltages"); } catch (Exception e) { log.Error("Error during inserting BMS_Voltages to database:  " + e.ToString()); }
            dbConnection.Close();
        }

        private static void updateMsgPartBMS_Temps(BMSTemps BMS_Temps, int ID_MSG)
        {
            dbConnection = new SqlCeConnection(getConnestionString());
            dbConnection.Open();
            SqlCeCommand cmd = new SqlCeCommand(DatabaseQueries.UPDATE_MSG_BMS_Temps, dbConnection);

            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_TempIdent, BMS_Temps.BMS_TempIdent);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp1, BMS_Temps.BMS_Temp1);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp2, BMS_Temps.BMS_Temp2);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp3, BMS_Temps.BMS_Temp3);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp4, BMS_Temps.BMS_Temp4);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp5, BMS_Temps.BMS_Temp5);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp6, BMS_Temps.BMS_Temp6);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.BMS_Temp7, BMS_Temps.BMS_Temp7);
            cmd.Parameters.AddWithValue("@" + DatabaseQueries.ID, ID_MSG);

            try { cmd.ExecuteNonQuery(); log.Info("Inserting BMS_Temps"); } catch (Exception e) { log.Error("Error during inserting v to database:  " + e.ToString()); }
            dbConnection.Close();
        }


    }
}
