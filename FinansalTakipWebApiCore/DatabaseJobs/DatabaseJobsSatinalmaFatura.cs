using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using FinansalTakipWebApiCore.Controllers;
using static FinansalTakipWebApiCore.Business.DataAccessLayerMssql;
using FinansalTakipWebApiCore.Business;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static partial class DataBaseJobsSatinalmaFatura
    {
        public static string SaveSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaFatura, "spSaveSatinalmaFatura");
        }
        public static string UpdateSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satinalmaFatura, "spSaveSatinalmaFatura");
        }
        public static string GetFilteredSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satinalmaFatura, "spGetFilteredSatinalmaFatura");
        }
        public static string DeleteSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject<SatinalmaFatura>(satinalmaFatura, "spDeleteSatinalmaFatura");
        }
    }
}
