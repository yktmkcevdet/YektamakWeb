using Models;

namespace ApiService
{
    partial class WebMethods
    {
        public static async Task<string> SaveCek(Cek cek)
        {
            return await PostAsyncMethod(cek,"SaveCek");
        }
        public static string GetFilteredCek(Cek cek)
        {
            return Post(cek, "GetFilteredCek");
        }
        public static async Task<string> GetCekByCekId(Cek cek)
        {
            return await PostAsyncMethod(cek, "GetCekByCekId");
        }
        public static async Task<string> DeleteCek(Cek cek)
        {
            return await DeleteAsyncMethod(cek, "DeleteCek");
        }
    }
}
