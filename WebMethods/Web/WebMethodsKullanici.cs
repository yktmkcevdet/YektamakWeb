using Models;
using Models.DTO;

namespace ApiService
{
    partial class WebMethods
    {
        public static string SaveKullanici(Kullanici kullanici)
        {
            return Post(kullanici, "SaveKullanici");
        }
        public static string  GetKullanici(Kullanici kullanici)
        {
            return Post(kullanici, "GetKullanici");
        }
        public static async Task<string> GetKullaniciAsync(Kullanici kullanici)
        {
            return await PostAsyncMethod(kullanici, "GetKullanici");
        }

        public static string GetKullaniciYetki(Kullanici kullanici)
        {
            return Post(kullanici,"GetKullaniciYetki");
        }
        
        public static async Task<string> SaveEkran(Ekran ekran)
        {
            return await PostAsyncMethod(ekran, "SaveEkran");
        }
        public static async Task<string> SaveYetki(Yetki yetki)
        {
            return await PostAsyncMethod(yetki, "SaveYetki");
        }
        public static async Task<string> DeleteEkran(Ekran ekran)
        {
            return await PostAsyncMethod(ekran, "DeleteEkran");
        }
        public static string GetAnaMenu(AnaMenu anaMenu)
        {
            return Post(anaMenu, "GetAnaMenu");
        }
        public static string GetMenu(Menu menu=null)
        {
            return Get("GetMenu");
        }
        public static string GetYetki(Yetki yetki)
        {
            return Post(yetki,"GetYetki");
        }

        public static async Task<string> SaveMenu(Menu menu)
        {
            return await PostAsyncMethod(menu, "SaveMenu");
        }
        public async Task<string> DeleteMenu(Menu menu)
        {
            return await PostAsyncMethod(menu, "DeleteMenu");
        }
    }
}
