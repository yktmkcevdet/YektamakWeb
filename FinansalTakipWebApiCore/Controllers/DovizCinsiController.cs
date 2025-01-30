using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DovizCinsiController
    {
        [HttpGet, Route("api/TumDovizCinsleri/")]
        public string TumDovizCinsleri()
        {
            string returnValue = "";
            returnValue = DataBaseJobsDovizCinsi.GetAllDovizCinsi();
            return returnValue;
        }
    }
}
