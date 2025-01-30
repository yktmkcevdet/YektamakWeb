using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class KDVController : Controller
    {
        [HttpGet, Route("api/GetAllKDV/")]
        public string GetAllKDV()
        {
            string returnValue = "";
            returnValue = DataBaseJobsKDV.GetAllKDV();
            return returnValue;
        }
    }
}
