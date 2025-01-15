using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatisProjeSafhaController : Controller
    {
        [HttpPost, Route("api/SaveSatisProjeSafhaList")]
        public string SaveSatisProjeSafha([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisProje>(restData, DataBaseJobsSatisProjeSafha.SaveSatisProjeSafhaList);
        }

        [HttpPost, Route("api/GetSatisProjeSafhaList")]
        public string GetSatisProjeSafhaList([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisProje>(restData, DataBaseJobsSatisProjeSafha.GetSatisProjeSafhaList);
        }

        [HttpPost, Route("api/DeleteSatisProjeSafha")]
        public string DeleteSatisProjeSafha([FromBody] string restData)
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
                int projeSafhaId = JsonConvert.DeserializeObject<int>(json);
                returnValue = DataBaseJobsSatisProjeSafha.DeleteSatisProjeSafha(projeSafhaId);
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }

        [HttpGet, Route("api/GetProjeAsamaTanimlari")]
        public string GetProjeAsamaTanimlari()
        {
            string returnValue = "";
            try
            {
                returnValue = DataBaseJobsSatisProjeSafha.GetProjeAsamaTanimlari();
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }

    }
}
