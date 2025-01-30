using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Linq.Expressions;
using Microsoft.SqlServer.Server;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsSatisProje
    {
        public static string SaveSatisProje(SatisProje satisProje)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satisProje, "spSaveSatisProje");
        }

        public static string GetFilteredSatisProje(SatisProje satisProje)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satisProje, "spGetFilteredSatisProje");
        }

        public static string DeleteSatisProje(SatisProje satisProje)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(satisProje,"spDeleteSatisProje");
        }

    }
}
