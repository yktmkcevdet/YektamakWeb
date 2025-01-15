using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatinalmaTeklifController:Controller
    {
        [HttpPost, Route("api/SaveSatinalmaTeklif")]
        public string SaveSatinalmaTeklif([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatinalmaTeklifBaslik>(restData, DataBaseJobsSatinalmaTeklif.SaveSatinalmaTeklif);
        }
    }
}
