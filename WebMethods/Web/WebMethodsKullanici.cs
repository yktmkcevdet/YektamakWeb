using Models;

namespace Requests
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
        public async Task<string> GetMenu()
        {
            return await GetAsyncMethod("GetMenu");
        }
        public static async Task<string> SaveMenu(Menu menu)
        {
            return await PostAsyncMethod(menu, "SaveMenu");
        }
        public static async Task<string> DeleteMenu(Menu menu)
        {
            return await PostAsyncMethod(menu, "DeleteMenu");
        }
    }
}
