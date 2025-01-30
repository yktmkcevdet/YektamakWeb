using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using Api.Business;


namespace Api.DatabaseJobs
{
    public static partial class DatabaseJobsSatinalmaSiparis
    {
        public static string SaveSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaSiparis, "spSaveSatinalmaSiparis");
        }
        public static string GetFilteredSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satinalmaSiparis, "spGetFilteredSatinalmaSiparis");
        }
        public static string DeleteSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(satinalmaSiparis, "spDeleteSatinalmaSiparis");
        }
    }
}
