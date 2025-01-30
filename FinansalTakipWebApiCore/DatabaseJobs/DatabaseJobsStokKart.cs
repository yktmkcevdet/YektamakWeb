using Api.Business;
using Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using static Api.Business.DataAccessLayerMssql;

namespace Api.DatabaseJobs
{
    public class DatabaseJobsStokKart
	{
		public static string SaveStokKart(StokKart stokKart)
		{
			return DataAccessLayer.dataAccesLayer.SaveObject(stokKart, "spSaveStokKart");
		}
		public static string GetMalzeme(Malzeme malzeme)
		{
			return DataAccessLayer.dataAccesLayer.GetObject(malzeme, "spGetMalzeme");
		}
		public static string GetStokKart(StokKart stokKart)
		{
			return DataAccessLayer.dataAccesLayer.GetObject(stokKart, "spGetStokKart");
		}
        public static string GetStokKartPdf(StokKart stokKart)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(stokKart, "spGetStokKartPdf");
        }
        public static string SaveMalzeme(Malzeme malzeme)
		{
			return DataAccessLayer.dataAccesLayer.SaveObject(malzeme, "spSaveMalzeme");
		}
        public static string GetParcaGrup(ParcaGrup parcaGrup)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(parcaGrup, "spGetParcaGrup");
        }
        public static string DeleteProjeDosya(Proje proje)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(proje, "spDeleteProjeDosya");
        }
        public static string GetMalzemeGrup(MalzemeGrup malzemeGrup)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(malzemeGrup, "spGetMalzemeGrup");
        }
        public static string GetStokTip(StokTip stokTip)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(stokTip, "spGetStokTip");
        }
        public static string GetProfilTip(ProfilTip profilTip)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(profilTip, "spGetProfilTip");
        }
        public static string GetOlcuBirim(OlcuBirim olcuBirim)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(olcuBirim, "spGetOlcuBirim");
        }
        public static string GetMalzemeStandart(MalzemeStandart malzemeStandart)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(malzemeStandart, "spGetMalzemeStandart");
        }
    }
}
