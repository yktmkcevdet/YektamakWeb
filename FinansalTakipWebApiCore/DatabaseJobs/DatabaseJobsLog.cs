using Api.Business;
using Models;
using Models.Models;

namespace Api.DatabaseJobs
{
    public class DatabaseJobsLog
    {
        public static string SaveErrorLog(ErrorLog errorLog)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(errorLog, "spSaveErrorLog");
        }
    }
}
