using Api.Business;
using Models;

namespace Api.DatabaseJobs
{
    public class DataBaseJobsSatisSiparisTeklifTalep
    {
        public static string SaveSatisSiparisTeklifTalep(SatisSiparisTeklifTalep satisSiparisTeklifTalep)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satisSiparisTeklifTalep, "spGetFilteredSatisSiparisTeklifTalep");
        }
        public static string GetFilteredSatisSiparisTeklifTalep(SatisSiparisTeklifTalep satisSiparisTeklifTalep)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satisSiparisTeklifTalep, "spGetFilteredSatisSiparisTeklifTalep");
        }
    }
}
