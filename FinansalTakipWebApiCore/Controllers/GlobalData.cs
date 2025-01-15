using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;

namespace FinansalTakipWebApiCore.Controllers
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
