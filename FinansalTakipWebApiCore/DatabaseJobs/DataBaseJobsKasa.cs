using Models;
using System.Data.SqlClient;
using System.Data;
using Api.Business;
namespace Api.DatabaseJobs
{
    public class DataBaseJobsKasa
    {
        public static string SaveKasa(Kasa kasa)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(kasa, "spSaveKasa");
        }
        public static string GetKasalar()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetKasalar");
        }
        public static string GetFilteredKasa(Kasa kasa)
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetFilteredKasa");
        }
        public static string DeleteKasa(Kasa kasa)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(kasa,"spDeleteKasa");
        }
    }
}
