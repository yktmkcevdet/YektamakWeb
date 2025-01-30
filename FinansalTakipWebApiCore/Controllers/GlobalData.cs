using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GlobalDataController:Controller
    {
        [HttpGet, Route("api/GetGlobalData/")]
        public string GlobalData()
        {
            string returnValue = "";
            returnValue = DatabaseJobsGlobalData.GetGlobalData();
            return returnValue;
        }
    }
}
