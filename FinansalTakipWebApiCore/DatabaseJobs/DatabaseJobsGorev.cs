using Models;
using Api.Business;

namespace Api.DatabaseJobs
{
    public class DatabaseJobsGorev
    {
        public static string GetFilteredGorev(Gorev gorev)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(gorev, "spGetFilteredGorev");
        }
    }
}
