using Api.Business;
using Models;
using System.Data;
using System.Data.SqlClient;
using static Api.Business.DataAccessLayerMssql;

namespace Api.DatabaseJobs
{
    public class DataBaseJobsSatinalmaTeklif
    {
        public static string SaveSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaTeklifBaslik, "spSaveSatinalmaTeklif");
        }
    }
}
