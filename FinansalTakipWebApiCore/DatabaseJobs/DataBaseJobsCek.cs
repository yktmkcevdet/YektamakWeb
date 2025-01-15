using FinansalTakipWebApiCore.Business;
using Models;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public class DataBaseJobsCek
    {
        public static string SaveCek(Cek cek)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(cek, "spSaveCek");
        }
        public static string GetFilteredCek(Cek cek)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(cek, "spGetFilteredCek");
        }
        public static string DeleteCek(Cek cek)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(cek, "spDeleteCek");
        }
    }
}
