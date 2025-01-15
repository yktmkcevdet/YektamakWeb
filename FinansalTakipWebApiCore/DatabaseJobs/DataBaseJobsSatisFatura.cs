using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Data.Common;
using FinansalTakipWebApiCore.Business;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static class DataBaseJobsSatisFatura
    {
        public static string GetFilteredSatisFatura(SatisFatura satisFatura)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satisFatura,"spGetFilteredSatisFatura");
        }
        public static string SaveSatisFatura(SatisFatura satisFatura)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satisFatura, "spSaveSatisFatura");
        }
        public static string DeleteSatisFatura(SatisFatura satisFatura)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(satisFatura, "spDeleteSatisFatura");
        }
    }
}
