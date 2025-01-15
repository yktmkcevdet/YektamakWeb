using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatisTahsilatPlaniControler : Controller
    {
        [HttpPost,Route("api/GetTahsilatPlanDesign")]
        public string GetTahsilatPlanDesign([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? restData = "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData = restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                string data = JsonConvert.DeserializeObject<string>(json);
                int siparisId = int.Parse(data);
                string returnValue = DataBaseJobsSatisTahsilatPlan.GetTahsilatPlanDesign(siparisId);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "Error 2: Serialization error:" + ex.Message;
            }
        }
        [HttpPost, Route("api/GetTahsilatPlaniBySiparisId")]
        public string GetTahsilatPlaniBySiparisId([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? restData = "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData = restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                string data = JsonConvert.DeserializeObject<string>(json);
                int siparisId = int.Parse(data);
                string returnValue = DataBaseJobsSatisTahsilatPlan.GetTahsilatPlaniBySiparisId(siparisId);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "Error 2: Serialization error:" + ex.Message;
            }
        }
        [HttpPost,Route("api/SaveTahsilatPlani")]
        public string SaveTahsilatPlani([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length-1] != '\"') ? restData+ "\"" : restData;

                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json= Encoding.UTF8.GetString(bytes);
                TahsilatPlani data= JsonConvert.DeserializeObject<TahsilatPlani>(json);
                string returnValue = DataBaseJobsSatisTahsilatPlan.SaveTahsilatPlani(data);
                return returnValue;
            }
            catch(Exception ex)
            {
                return "Error 2: Serializatin error: "+ ex.Message;
            }
        }
        [HttpPost,Route("api/GetPlanOdemeBySiparisId")]
        public string GetPlanOdemeBySiparisId([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1]!= '\"') ? restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string data = Encoding.UTF8.GetString(bytes);
                int tahsilatPlanId = JsonConvert.DeserializeObject<int>(data);

                return DataBaseJobsSatisTahsilatPlan.GetPlanOdemeBySiparisId(tahsilatPlanId);
            }
            catch(Exception ex)
            {
                return "Error 2: Serialization error : " + ex.Message;
            }
        }
        [HttpPost,Route("api/UpdatePlanOdeme")]
        public string UpdatePlanOdeme([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string data = Encoding.UTF8.GetString(bytes);
                List<PlanOdeme> planOdemeList = JsonConvert.DeserializeObject<List<PlanOdeme>>(data);

                return DataBaseJobsSatisTahsilatPlan.UpdatePlanOdeme(planOdemeList);
            }
            catch (Exception ex)
            {
                return "Error 2: Serialization error : " + ex.Message;
            }
        }
    }
    
}
