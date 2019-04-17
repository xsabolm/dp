using connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Model
    {
        private const bool CondistionNewRunWasNotDetected = false;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Mensuration mensuration;
        private Discipline actualDisciplin;
        private Run actualRun;
        private List<Mensuration> allMensurations;

        internal Mensuration Mensuration { get => mensuration; set => mensuration = value; }
        public Discipline ActualDisciplin { get => actualDisciplin; set => actualDisciplin = value; }
        public List<Mensuration> AllMensurations { get => allMensurations; set => allMensurations = value; }
        public Run ActualRun { get => actualRun; set => actualRun = value; }

        public void loadMensurations()
        {
            AllMensurations = LoadModelFromDataBase.loadMensuration();
        }

        public void loadAllMeranieFromDatabase(int idMensuration)
        {
            Mensuration = LoadModelFromDataBase.getAllMensurationFromDataBase(idMensuration);
        }

        public void createModel()
        {
            Mensuration = new Mensuration();
        }

        internal void closeDiscipline()
        {
            if (ActualDisciplin != null)
            {
                ActualRun.FinishTime = DateTime.Now;
                ActualDisciplin.Comment = DateTime.Now.ToLongTimeString();
                ActualDisciplin.ListRuns.Add(ActualRun);
                Mensuration.ListDiscipline.Add(ActualDisciplin);
            }

        }

        internal Boolean createNewDiscipline()
        {
            if (Mensuration != null)
            {
                ActualDisciplin = new Discipline(getTempIdForDicsipline(), Mensuration.ID);
                createNewRun(CondistionNewRunWasNotDetected);
                return true;
            }
            else
            {
                MessageBoxes.didNotSetConnection();
                return false;
            }
        }

        internal void createNewRun(bool CondistionNewRunWasDetected)
        {
            if (CondistionNewRunWasDetected)
            {
                log.Info("NEW RUN WAS DETECTED");
                ActualRun.FinishTime = DateTime.Now;
                ActualDisciplin.ListRuns.Add(ActualRun);
                ActualRun = new Run(ActualDisciplin.ID);
            }
            else
            {
                ActualRun = new Run(ActualDisciplin.ID);
            }
        }


        internal void createNewMsg(JsonMsg msg)
        {
            if (ActualRun != null)
            {
                log.Info("ID msg: " + msg.Id);
                ActualRun.ListMsg.Add(new Msg(msg));
            }
        }

        private int getTempIdForRun() { return (ActualDisciplin.ListRuns.Count + 1); }
        private int getTempIdForDicsipline() { return (Mensuration.ListDiscipline.Count + 1); }
    }
}
