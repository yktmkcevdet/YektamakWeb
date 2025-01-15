using FinansalTakipWebApiCore.Business;
using Models;
using System.Data;
using System.Data.SqlClient;
using static FinansalTakipWebApiCore.Business.DataAccessLayerMssql;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public class DataBaseJobsSatinalmaTeklif
    {
        public static string SaveSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaTeklifBaslik, "spSaveSatinalmaTeklif");
        }
    }
}
