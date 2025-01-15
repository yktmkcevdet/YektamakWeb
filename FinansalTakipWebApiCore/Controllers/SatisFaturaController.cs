using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatisFaturaControler : Controller
    {
        [HttpPost,Route("api/GetFilteredSatisFatura")]
        public string GetFilteredSatisFatura([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisFatura>(restData, DataBaseJobsSatisFatura.GetFilteredSatisFatura);
        }
        [HttpPost,Route("api/SaveSatisFatura")]
        public string SaveSatisFatura([FromBody]string restData)
        {
            return GeneralMethods.ResultData<SatisFatura>(restData, DataBaseJobsSatisFatura.SaveSatisFatura);
        }
        [HttpPost, Route("api/DeleteSatisFatura")]
        public string DeleteSatisFatura([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisFatura>(restData, DataBaseJobsSatisFatura.DeleteSatisFatura);
        }
    }
}