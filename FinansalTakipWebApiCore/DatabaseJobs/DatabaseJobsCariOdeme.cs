using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using FinansalTakipWebApiCore.Business;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public class DatabaseJobsCariOdeme
    {
        public static string GetCariOdemeComboLists()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetCariOdemeComboLists");
        }
        public static string SaveCariOdeme(CariOdeme cariOdeme)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(cariOdeme, "spSaveCariOdeme");
        }
        public static string GetFilteredCariOdeme(CariOdeme cariOdeme)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(cariOdeme, "spGetFilteredCariOdeme");
        }
        public static string DeleteCariOdeme(CariOdeme cariOdeme)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(cariOdeme, "spDeleteCariOdeme");
        }
    }
}
