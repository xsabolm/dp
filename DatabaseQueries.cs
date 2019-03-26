using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection
{
    class DatabaseUtils
    {
        public static String DATABASE_FILENAME = "\\stubaGreenTeamDataBase.sdf";

        public static String MERANIE_CAS = "cas_zacatia";
        public static String MERANIE_TYP = "typ";
        public static String MERANIE_DETAILY= "detaily";
        public static String MERANIE_LOKACIA = "lokacia";

        public static String ID = "Id";
        public static String DISCIPLINY_TYP = "typ_discipliny";
        public static String ID_MERANIA = "Id_merania";

        public static String OKRUH_CAS = "cas_okruhu";

        public static String ID_DISCIPLINA = "Id_disciplina";
        public static String SPRAVA_CAS_PRIJATIA = "cas_prijatia_spravy";
        public static String ID_OKRUHU = "Id_okruhu";

        public static String SELECT_ALL_MERANIA = "SELECT * FROM meranie;";
        public static String SELECT_ALL_DISCIPLINA = "SELECT * FROM disciplina ;";
        public static String SELECT_ALL_OKRUH = "SELECT * FROM okruh;";
        public static String SELECT_ALL_SPRAVA = "SELECT * FROM sprava;";

        internal static String selectSpravyByDisciplina(int idDisciplina)
        {
            return "SELECT * FROM sprava where Id_disciplina=" + idDisciplina + ";";
        }

        internal static String selectMeranieById(int idMeranie)
        {
            return "SELECT * FROM meranie where Id=" + idMeranie + ";";
        }

        internal static String selectOkruhByDisciplina(int idDisciplina)
        {
            return "SELECT * FROM okruh where Id_disciplina=" + idDisciplina + ";";
        }


        internal static String selectDisciplinaByMeranie(int idMeranie)
        {
            return "SELECT * FROM disciplina where Id_merania=" + idMeranie + ";";
        }

        internal static String selectSpravyByMeranie(int idMeranie)
        {
            return "SELECT sprava.Id, sprava.Id_disciplina,sprava.Id_okruh,sprava.cas_prijatia_spravy FROM sprava inner JOIN disciplina ON sprava.Id_disciplina=disciplina.Id where disciplina.Id_merania = " + idMeranie + ";";
        }

        internal static string selectSpravyByOkruh(int idOkruh)
        {
            return "SELECT * FROM sprava where Id_okruh=" + idOkruh + ";";
        }
    }
}
