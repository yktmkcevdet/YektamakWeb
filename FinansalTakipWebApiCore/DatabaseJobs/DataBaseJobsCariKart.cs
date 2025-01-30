using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using Api.Business;

namespace Api.DatabaseJobs
{
    public class DataBaseJobsCariKart
    {
        public static string SaveCariKart(CariKart cariKart)
        {
			return DataAccessLayer.dataAccesLayer.SaveObject(cariKart, "spSaveCariKart");
        }
        public static string GetFilteredCariKartlar(CariKart cariKart)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(cariKart, "spGetFilteredCariKartlar");
        }
        public static string DeleteCariKart(CariKart cariKart)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(cariKart, "spDeleteCariKart");
        }
    }
}
