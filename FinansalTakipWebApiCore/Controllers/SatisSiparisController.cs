using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatisSiparisControler : Controller
    {
        [HttpPost, Route("api/SaveSatisSiparis")]
        public string SaveSatisSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisSiparis>(restData, DataBaseJobsSatisSiparis.SaveSatisSiparis);
        }
        [HttpPost, Route("api/DeleteSatisSiparis")]
        public string DeleteSatisSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisSiparis>(restData, DataBaseJobsSatisSiparis.DeleteSatisSiparis);
        }
        [HttpPost,Route("api/GetFilteredSatisSiparis")]
        public string GetFilteredSatisSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisSiparis>(restData, DataBaseJobsSatisSiparis.GetFilteredSatisSiparis);
        }
    }
}

