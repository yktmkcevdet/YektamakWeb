using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace FinansalTakipWebApiCore.Controllers
{
    public class TahakkukFisiController
    {
        [HttpPost, Route("api/SaveTahakkukFisi")]
        public string SaveTahakkukFisi([FromBody] string restData)
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
                restData = Encoding.UTF8.GetString(bytes);
                TahakkukFisi tahakkukFisi = JsonConvert.DeserializeObject<TahakkukFisi>(restData);
                returnValue = DatabaseJobsTahakkukFisi.SaveTahakkukFisi(tahakkukFisi);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
        [HttpPost, Route("api/GetFilteredTahakkukFisi")]
        public string GetFilteredTahakkukFisi([FromBody] string restData)
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
                restData = Encoding.UTF8.GetString(bytes);
                TahakkukFisi tahakkukFisi = JsonConvert.DeserializeObject<TahakkukFisi>(restData);
                returnValue = DatabaseJobsTahakkukFisi.GetFilteredTahakkukFisi(tahakkukFisi);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
        [HttpPost, Route("api/DeleteTahakkukFisi")]
        public string DeleteTahakkukFisi([FromBody] string restData)
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
                restData = Encoding.UTF8.GetString(bytes);
                TahakkukFisi tahakkukFisi = JsonConvert.DeserializeObject<TahakkukFisi>(restData);
                returnValue = DatabaseJobsTahakkukFisi.DeleteTahakkukFisi(tahakkukFisi);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
    }
}
