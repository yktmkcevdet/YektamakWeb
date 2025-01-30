using Models;
using Api.Business;
using Models;

namespace Api.DatabaseJobs
{
    public class DataBaseJobsButtonImage
    {
        public static string GetButtonImage(ButtonImage buttonImage)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(buttonImage, "spGetButtonImage");
        }
    }
}
