using Api.Business;
using Models;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsAnaVeri
    {
        public static string GetParcaGrupList()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetParcaGrupList");
        }
        public static string GetParcaAltGrupList()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetParcaAltGrupList");
        }
    }
}
