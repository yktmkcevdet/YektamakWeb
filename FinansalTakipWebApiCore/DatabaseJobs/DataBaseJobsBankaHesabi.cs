using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsBankaHesabi
    {
        public static string SaveBankaHesabi(BankaHesabi bankaHesabi)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(bankaHesabi, "spSaveBankaHesabi");
        }

        public static string DeleteBankaHesabi(BankaHesabi bankaHesabi)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(bankaHesabi, "spDeleteBankaHesabi");
        }

        public static string GetFilteredBankaHesabi(BankaHesabi bankaHesabi)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(bankaHesabi, "spGetFilteredBankaHesabi");
        }
    }
}