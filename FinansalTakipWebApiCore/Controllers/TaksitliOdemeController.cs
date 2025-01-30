using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Api.Controllers
{
    public class TaksitliOdemeController:Controller
    {
        [HttpPost, Route("api/SaveTaksitliOdeme")]
        public string SaveTaksitliOdeme([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                //TaksitliOdeme data = JsonConvert.DeserializeObject<TaksitliOdeme>(json);
                JObject jsonObject = JObject.Parse(json);
                TaksitliOdeme taksitliOdeme = jsonObject["TaksitliOdeme"].ToObject<TaksitliOdeme>();
                List<TaksitOdemesi> taksitOdemesiList = jsonObject["TaksitOdemesiList"].ToObject<List<TaksitOdemesi>>();

                
                string returnValue = DatabaseJobsTaksitliOdeme.SaveTakstiliOdeme(taksitliOdeme, taksitOdemesiList);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "Error 2: Serializatin error: " + ex.Message;
            }
        }
        [HttpPost, Route("api/GetFilteredTaksitliOdeme")]   
        public string GetFilteredTaksitliOdeme([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;

                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                TaksitliOdemeFiltre data = JsonConvert.DeserializeObject<TaksitliOdemeFiltre>(json);
                string returnValue = DatabaseJobsTaksitliOdeme.GetFilteredTakstiliOdeme(data);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "Error 2: Serializatin error: " + ex.Message;
            }
        }
        [HttpPost, Route("api/GetTaksitOdemesiByTaksitliOdemeId")]
        public string GetTaksitOdemesiByTaksitliOdemeId([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;

                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                int data = JsonConvert.DeserializeObject<int>(json);
                string returnValue = DatabaseJobsTaksitliOdeme.GetTaksitOdemesiByTaksitliOdemeId(data);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "Error 2: Serializatin error: " + ex.Message;
            }
        }
        [HttpPost, Route("api/DeleteTaksitliOdeme")]
        public string DeleteTaksitliOdeme([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;

                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                int data = JsonConvert.DeserializeObject<int>(json);
                string returnValue = DatabaseJobsTaksitliOdeme.DeleteTakstiliOdeme(data);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "Error 2: Serializatin error: " + ex.Message;
            }
        }
    }
}
