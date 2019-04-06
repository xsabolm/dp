using connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public static class LoadModelFromDataBase
    {
        public static Mensuration getAllMensurationFromDataBase(int ID)
        {
            DataTable table = DataBaseServices.selectFromDatabase(DatabaseQueries.selectMensurationById(ID));

            int id = Convert.ToInt32(table.Rows[0][DatabaseQueries.ID]);
            DateTime startTime = Convert.ToDateTime(table.Rows[0][DatabaseQueries.START_TIME]);
            String comment = table.Rows[0][DatabaseQueries.COMMENT].ToString();
            String locality = table.Rows[0][DatabaseQueries.LOCALITY].ToString();
            List<Discipline> listDiscipline = getListDisciplin(id);

            return new Mensuration(id, startTime, comment, locality, listDiscipline);
        }

        internal static List<Mensuration> loadMensuration()
        {
            DataTable table = DataBaseServices.selectFromDatabase(DatabaseQueries.SELECT_ALL_MENSURATION);
            List<Mensuration> list = new List<Mensuration>();
            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row[DatabaseQueries.ID]);
                DateTime startTime = Convert.ToDateTime(row[DatabaseQueries.START_TIME]);
                String comment = row[DatabaseQueries.COMMENT].ToString();
                String locality = row[DatabaseQueries.LOCALITY].ToString();

                list.Add(new Mensuration(id, startTime, comment, locality));
            }
            return list;
        }

        static private List<Discipline> getListDisciplin(int idMensuration)
        {
            List<Discipline> listDiscipline = new List<Discipline>();
            DataTable table = DataBaseServices.selectFromDatabase(DatabaseQueries.selectDisciplineByMensurationId(idMensuration));

            foreach (DataRow row in table.Rows)
            {
                int idDiscipline = Convert.ToInt32(row[DatabaseQueries.ID]);
                listDiscipline.Add(new Discipline(idDiscipline, idMensuration, DatabaseQueries.COMMENT, row[DatabaseQueries.NAME].ToString(), getListRuns(idDiscipline)));
            }

            return listDiscipline;
        }

        static private List<Run> getListRuns(int idDiscipline)
        {
            List<Run> listRun = new List<Run>();
            DataTable table = DataBaseServices.selectFromDatabase(DatabaseQueries.selectRunByDisciplineId(idDiscipline));

            foreach (DataRow row in table.Rows)
            {
                DateTime finishTime = Convert.ToDateTime("1000-01-01");
                int idRun = Convert.ToInt32(row[DatabaseQueries.ID]);
                if ("null".Equals(row[DatabaseQueries.FINISH_TIME].ToString())) { finishTime = Convert.ToDateTime(row[DatabaseQueries.FINISH_TIME]); }
                listRun.Add(new Run(idRun, idDiscipline, Convert.ToDateTime(row[DatabaseQueries.START_TIME]), finishTime, Convert.ToInt32(row[DatabaseQueries.RUN_NUMBER]) , row[DatabaseQueries.COMMENT].ToString(), getListMsg(idRun)));
            }

            return listRun;
        }

        static private List<Msg> getListMsg(int idOkruh)
        {
            List<Msg> listMsg = new List<Msg>();
            DataTable table = DataBaseServices.selectFromDatabase(DatabaseQueries.selectMsgByRunId(idOkruh));

            foreach (DataRow row in table.Rows)
            {
               // listMsg.Add(new Msg(Convert.ToInt32(row[DatabaseQueries.ID]), idOkruh, Convert.ToDateTime(row[DatabaseQueries.RECEIPT_TIME])));
                listMsg.Add(new Msg(row));

            }
            return listMsg;
        }
    }
}
