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
        public static Meranie getAllMeranieObjectFromDataBase(int ID)
        {
            DataTable table = DataBaseServices.getDataFromDatabase(DatabaseUtils.selectMeranieById(ID));

            int id = Convert.ToInt32(table.Rows[0][DatabaseUtils.ID]);
            DateTime casMerania = Convert.ToDateTime(table.Rows[0][DatabaseUtils.MERANIE_CAS]);
            Boolean typ = Convert.ToBoolean(table.Rows[0][DatabaseUtils.MERANIE_TYP]);
            String detaily = table.Rows[0][DatabaseUtils.MERANIE_DETAILY].ToString();
            String lokacia = table.Rows[0][DatabaseUtils.MERANIE_LOKACIA].ToString();
            List<Disciplina> listDisciplin = getListDisciplin(id);

            return new Meranie(id, casMerania, typ, detaily, lokacia, listDisciplin);
        }

        internal static List<Meranie> loadMernia()
        {
            DataTable table = DataBaseServices.getDataFromDatabase(DatabaseUtils.SELECT_ALL_MERANIA);
            List<Meranie> list = new List<Meranie>();
            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row[DatabaseUtils.ID]);
                DateTime casMerania = Convert.ToDateTime(row[DatabaseUtils.MERANIE_CAS]);
                Boolean typ = Convert.ToBoolean(row[DatabaseUtils.MERANIE_TYP]);
                String detaily = row[DatabaseUtils.MERANIE_DETAILY].ToString();
                String lokacia = row[DatabaseUtils.MERANIE_LOKACIA].ToString();

                list.Add(new Meranie(id, casMerania, typ, detaily, lokacia));
            }
            return list;
        }

        static private List<Disciplina> getListDisciplin(int idMeranie)
        {
            List<Disciplina> listDisciplin = new List<Disciplina>();
            DataTable table = DataBaseServices.getDataFromDatabase(DatabaseUtils.selectDisciplinaByMeranie(idMeranie));

            foreach (DataRow row in table.Rows)
            {
                int idDisciplina = Convert.ToInt32(row[DatabaseUtils.ID]);
                listDisciplin.Add(new Disciplina(idDisciplina, idMeranie, DatabaseUtils.DISCIPLINY_TYP, getListOkruhov(idDisciplina)));
            }

            return listDisciplin;
        }

        static private List<Okruh> getListOkruhov(int idDisciplina)
        {
            List<Okruh> listOkruhov = new List<Okruh>();
            DataTable table = DataBaseServices.getDataFromDatabase(DatabaseUtils.selectOkruhByDisciplina(idDisciplina));

            foreach (DataRow row in table.Rows)
            {
                int idOkruh = Convert.ToInt32(row[DatabaseUtils.ID]);
                listOkruhov.Add(new Okruh(idOkruh, idDisciplina, Convert.ToInt32(row[DatabaseUtils.OKRUH_CAS]), getListSprav(idOkruh)));
            }

            return listOkruhov;
        }

        static private List<Sprava> getListSprav(int idOkruh)
        {
            List<Sprava> listSprav = new List<Sprava>();
            DataTable table = DataBaseServices.getDataFromDatabase(DatabaseUtils.selectSpravyByOkruh(idOkruh));

            foreach (DataRow row in table.Rows)
            {
                listSprav.Add(new Sprava(Convert.ToInt32(row[DatabaseUtils.ID]), idOkruh, Convert.ToDateTime(row[DatabaseUtils.SPRAVA_CAS_PRIJATIA])));
            }
            return listSprav;
        }
    }
}
