using System.Text;
using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    public class KrediKartiController
    {
        [HttpPost, Route("api/SaveKrediKarti")]
        public string SaveKrediKarti([FromBody] string restData)
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
                KrediKarti krediKarti = JsonConvert.DeserializeObject<KrediKarti>(restData);
                returnValue = DataBaseJobsKrediKarti.SaveKrediKarti(krediKarti);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
        [HttpPost, Route("api/GetFilteredKrediKarti")]
        public string GetFilteredKrediKarti([FromBody] string restData)
        {
            return GeneralMethods.ResultData<KrediKarti>(restData, DataBaseJobsKrediKarti.GetFilteredKrediKarti);
        }
        [HttpPost, Route("api/DeleteKrediKarti")]
        public string DeleteKrediKarti([FromBody] string restData)
        {
            return GeneralMethods.ResultData<KrediKarti>(restData, DataBaseJobsKrediKarti.DeleteKrediKarti);
        }
    }
}
