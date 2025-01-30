using Models;

namespace ApiService
{
    partial class WebMethods
    {
        public static async Task<string> SaveBankaHesabi(BankaHesabi bankaHesabi)
        {
            return await PostAsyncMethod(bankaHesabi, "SaveBankaHesabi");
        }
       
        public static async Task<string> DeleteBankaHesabi(BankaHesabi bankaHesabi)
        {
            return await DeleteAsyncMethod(bankaHesabi, "DeleteBankaHesabi");
        }
        public static string GetFilteredBankaHesabi(BankaHesabi bankaHesabi)
        {
            return Post(bankaHesabi, "GetFilteredBankaHesabi");
        }
    }
}
