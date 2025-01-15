using Models;
using FinansalTakipWebApiCore.Business;
using Models;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public class DataBaseJobsButtonImage
    {
        public static string GetButtonImage(ButtonImage buttonImage)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(buttonImage, "spGetButtonImage");
        }
    }
}
