using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace Api.Controllers
{
    public class TedarikciIadeFaturaControler : Controller
    {
        [HttpPost,Route("api/GetFilteredTedarikciIadeFatura")]
        public string GetFilteredTedarikciIadeFatura([FromBody] string restData)
        {
            try
            {
                string returnValue = "";
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json=Encoding.UTF8.GetString(bytes);
                TedarikciIadeFatura tedarikciIadeFatura=JsonConvert.DeserializeObject<TedarikciIadeFatura>(json);
                returnValue = DataBaseJobsTedarikciIadeFatura.GetFilteredTedarikciIadeFatura(tedarikciIadeFatura);
                
                return returnValue;
            }
            catch(Exception ex)
            {
                return "error 2: Serialization error :" + ex.Message;
            }

        }
        [HttpPost,Route("api/SaveTedarikciIadeFatura")]
        public string SaveTedarikciIadeFatura([FromBody]string restData)
        {
            try
            {
                restData = (restData[0]!='\"')?"\""+restData:restData;
                restData = (restData[restData.Length-1]!='\"')?restData+"\"":restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json=Encoding.UTF8.GetString(bytes);
                TedarikciIadeFatura tedarikciIadeFatura=JsonConvert.DeserializeObject<TedarikciIadeFatura>(json);
                string returnValue = DataBaseJobsTedarikciIadeFatura.SaveTedarikciIadeFatura(tedarikciIadeFatura);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 2: Serialization error :" + ex.Message;
            }
        }
        [HttpPost, Route("api/GetTedarikciIadeFaturaById")]
        public string GetTedarikciIadeFaturaById([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                int tedarikciIadeFaturaId = JsonConvert.DeserializeObject<int>(json);
                string returnValue = DataBaseJobsTedarikciIadeFatura.GetTedarikciIadeFaturaById(tedarikciIadeFaturaId);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 2: Serialization error :" + ex.Message;
            }
        }
        [HttpPost, Route("api/DeleteTedarikciIadeFatura")]
        public string DeleteTedarikciIadeFatura([FromBody] string restData)
        {
            try
            {
                restData = (restData[0] != '\"') ? "\"" + restData : restData;
                restData = (restData[restData.Length - 1] != '\"') ? restData + "\"" : restData;
                byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
                string json = Encoding.UTF8.GetString(bytes);
                int tedarikciIadeFaturaId = JsonConvert.DeserializeObject<int>(json);
                string returnValue = DataBaseJobsTedarikciIadeFatura.DeleteTedarikciIadeFatura(tedarikciIadeFaturaId);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 2: Serialization error :" + ex.Message;
            }
        }
    }
}