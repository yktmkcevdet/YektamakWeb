using FinansalTakipWebApiCore.Business;
using Models;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static FinansalTakipWebApiCore.Business.DataAccessLayerMssql;
namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static class DatabaseJobsKullanici
    {
        public static string SaveKullanici(Kullanici kullanici)
        {
			return DataAccessLayer.dataAccesLayer.SaveObject(kullanici, "spSaveKullanici");
		}
        public static string GetKullanici(Kullanici kullanici)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(kullanici, "spGetKullanici");
		}
        public static string GetKullaniciYetki(Kullanici kullanici)
        {
			return DataAccessLayer.dataAccesLayer.GetObject(kullanici, "spGetKullaniciYetki");
		}
        public static string SaveEkran(Ekran ekran)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(ekran, "spSaveEkran");
        }
        public static string SaveYetki(Yetki yetki)
        {
			return DataAccessLayer.dataAccesLayer.SaveObject(yetki, "spSaveYetki");
		}
        public static string DeleteEkran(Ekran ekran)
        {
			return DataAccessLayer.dataAccesLayer.DeleteObject(ekran, "spDeleteEkran");
		}
        public static string GetMenu()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetMenu");
        }
        public static string SaveMenu(Menu menu)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(menu, "spSaveMenu");
        }
        public static string DeleteMenu(Menu menu)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(menu, "spDeleteMenu");
        }
    }
}
