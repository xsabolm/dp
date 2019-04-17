using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class ProcessingLiveData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        int lastId = -1;
        List<JsonMsg> queueWait = new List<JsonMsg>();

        public int LastId { get => lastId; set => lastId = value; }

        private JsonMsg receivingRawJson(String rawJson)
        {
            JsonMsg jsonSprava = null;
            try
            {
                jsonSprava = JsonConvert.DeserializeObject<JsonMsg>(rawJson);
            }
            catch (Exception e)
            {
                log.Info("Error in prasing JSON: " + rawJson + "/n " + e.ToString());
            };
            return jsonSprava;
        }

        public void processing(String rawJson)
        {
            Console.WriteLine(rawJson);
            JsonMsg actualProcessingSprava = receivingRawJson(rawJson);
            if (actualProcessingSprava.Data == null)
            {
                if (actualProcessingSprava.Id == -1)
                {
                    AppController.get.SelectedDiscipline.reciviedErrorMsg();
                }
                return;
            }
            if (actualProcessingSprava == null) return;
            if (lastId == actualProcessingSprava.Id) return;

            if (LastId == -1)
            {
                LastId = actualProcessingSprava.Id;
                AppController.get.SelectedDiscipline.addNewMsg(actualProcessingSprava);
                return;
            }
            else
            {
                if (actualProcessingSprava.Id == (LastId + 1))
                {
                    if (queueWait.Count == 0)
                    {
                        LastId = actualProcessingSprava.Id;
                        if (AppController.get.SelectedDiscipline != null)
                        {
                            AppController.get.SelectedDiscipline.addNewMsg(actualProcessingSprava);
                        }
                        return;
                    }
                    else
                    {
                        queueWait.Add(actualProcessingSprava);
                    }
                }
                else if (actualProcessingSprava.Id < (LastId + 1))
                {
                    queueWait.Add(actualProcessingSprava);
                }
                else if (actualProcessingSprava.Id > LastId)
                {
                    queueWait.Add(actualProcessingSprava);
                }
            }

            if (queueWait.Count == 3)
            {
                //queueWait.Sort();
                //sortovat
                queueWait.ForEach(sprava =>
                {
                    //AppController.get.Model.createNewMsg(sprava);
                    if (AppController.get.SelectedDiscipline != null)
                    {
                        AppController.get.SelectedDiscipline.addNewMsg(sprava);
                    }
                    LastId = sprava.Id;
                });
                queueWait.Clear();
            }
        }
    }
}
