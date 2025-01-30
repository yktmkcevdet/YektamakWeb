using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Api.Controllers
{
    public class LogController:Controller
    {
        [HttpPost, Route("api/SaveErrorLog/")]
        public string SaveErrorLog([FromBody] string restData)
        {
            return GeneralMethods.ResultData<ErrorLog>(restData, DatabaseJobsLog.SaveErrorLog);
        }
    }
}
