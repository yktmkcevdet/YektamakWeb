using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;



namespace FinansalTakipWebApiCore.Controllers
{
    public class ProjeKodController : Controller
    {
        private static JsonConverter[] jsonConverters;
        private JsonSerializerSettings jsonSerializerSettings;

        static ProjeKodController()
        {
            IsoDateTimeConverter converter1 = new IsoDateTimeConverter();
            converter1.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonConverters = new JsonConverter[] { converter1 };
        }

        public ProjeKodController()
        {
            JsonSerializerSettings settings1 = new JsonSerializerSettings();
            settings1.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings1.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings1.Converters = jsonConverters;
            this.jsonSerializerSettings = settings1;
        }

        [HttpPost, Route("api/MaxProjeNo/")]
        public string MaxProjeNo([FromBody] string restData)
        {
            string returnValue = "";
            try
            {
                if (restData[0] != '\"')
                {
                    restData = "\"" + restData;
                }
                if (restData[restData.Length - 1] != '\"')
                {
                    restData = restData + "\"";
                }
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                int markaId = JsonConvert.DeserializeObject<int>(json);
                returnValue = DataBaseJobsProjeKod.GetMaxProjeNo(markaId);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }

        [HttpPost, Route("api/ProjeKodKaydet/")]
        public string ProjeKodKaydet([FromBody] string restData)
        {
            string returnValue = "";
            try
            {
                if (restData[0] != '\"')
                {
                    restData = "\"" + restData;
                }
                if (restData[restData.Length - 1] != '\"')
                {
                    restData = restData + "\"";
                }

                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                Proje projeKod = JsonConvert.DeserializeObject<Proje>(json);
                returnValue = DataBaseJobsProjeKod.SaveProjeKod(projeKod);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }

        [HttpGet, Route("api/UnassignedProjeKod/")]
        public string UnassignedProjeKod()
        {
            return DataBaseJobsProjeKod.UnassignedProjeKod();
        }

        [HttpGet, Route("api/GetAllAssignedProjeKod/")]
        public string GetAllAssignedProjeKod()
        {
            string returnValue = "";
            try
            {
                returnValue = DataBaseJobsProjeKod.GetAllAssignedProjeKod();
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }

        [HttpPost, Route("api/GetProjeKodById")]
        public string GetProjeKodById([FromBody] string restData)
        {
            string returnValue = "";
            try
            {
                if (restData[0] != '\"')
                {
                    restData = "\"" + restData;
                }
                if (restData[restData.Length - 1] != '\"')
                {
                    restData = restData + "\"";
                }
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                int projeKodID = JsonConvert.DeserializeObject<int>(json);
                returnValue = DataBaseJobsProjeKod.GetProjeKodById(projeKodID);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
        [HttpGet, Route("api/GetAllOrderedProjeKod")]
        public string GetAllOrderedProjeKod()
        {
            try
            {
                string returnValue = "";
                returnValue = DataBaseJobsProjeKod.GetAllOrderedProjeKod();
                return returnValue;
            }
            catch(Exception ex)
            {
                return "Error 2: Serializatin error:" + ex.Message;
            }
        }
        [HttpPost, Route("api/GetProjeKodByUserId/")]
        public string GetProjeKodByUserId([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Proje>(restData, DataBaseJobsProjeKod.GetProjeKodByUserId);
        }
    }
}