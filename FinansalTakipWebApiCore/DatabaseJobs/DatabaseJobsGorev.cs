using Models;
using FinansalTakipWebApiCore.Business;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public class DatabaseJobsGorev
    {
        public static string GetFilteredGorev(Gorev gorev)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(gorev, "spGetFilteredGorev");
        }
    }
}
