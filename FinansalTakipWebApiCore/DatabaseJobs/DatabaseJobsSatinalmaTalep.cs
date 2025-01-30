using Api.Business;
using Models;
using System.Data;
using System.Data.SqlClient;
using static Api.Business.DataAccessLayerMssql;

namespace Api.DatabaseJobs
{
    public class DatabaseJobsSatinalmaTalep
    {
        public static string GetTalepTipleri()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetTalepTipleri");
        }
        public static string SaveSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaTalepBaslik, "spSaveSatinalmaTalep");
        }
		public static string GetSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
		{
			return DataAccessLayer.dataAccesLayer.GetObject(satinalmaTalepBaslik,"spGetSatinalmaTalepBaslik");
		}
        public static string DeleteSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(satinalmaTalepBaslik, "spDeleteSatinalmaTalep");
        }
        public static string GetFilteredSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satinalmaTalepDetay, "spGetFilteredSatinalmaTalepDetay");
        }
        public static string SaveSatinalmaTeklifTalep(List<SatinalmaTalepDetay> satinalmaTalepDetayList)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaTalepDetayList, "spSaveSatinalmaTeklifTalep");
        }
    }
}
