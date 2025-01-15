using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatinalmSiparisController : Controller
    {
        [HttpPost, Route("api/SaveSatinalmaSiparis")]
        public string SaveSatinalmaSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatinalmaSiparis>(restData, DatabaseJobsSatinalmaSiparis.SaveSatinalmaSiparis);
        }


        [HttpPost, Route("api/GetFilteredSatinalmaSiparis")]
        public string GetSatinalmaSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatinalmaSiparis>(restData, DatabaseJobsSatinalmaSiparis.GetFilteredSatinalmaSiparis);
        }


        [HttpPost, Route("api/DeleteSatinalmaSiparis")]
        public string DeleteSatinalmaSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatinalmaSiparis>(restData, DatabaseJobsSatinalmaSiparis.DeleteSatinalmaSiparis);
        }
    }
}
