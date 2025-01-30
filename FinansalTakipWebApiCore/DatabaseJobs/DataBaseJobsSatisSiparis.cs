using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Data.Common;
using static Api.Business.DataAccessLayerMssql;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsSatisSiparis
    {
        public static string SaveSatisSiparis(SatisSiparis satisSiparis)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satisSiparis, "spSaveSatisSiparis");
        }
        public static string DeleteSatisSiparis(SatisSiparis satisSiparis)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(satisSiparis, "spDeleteSatisSiparis");
        }
        public static string GetFilteredSatisSiparis(SatisSiparis satisSiparis)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satisSiparis, "spGetFilteredSatisSiparis");
        }
    }
}
