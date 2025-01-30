using Models;

namespace ApiService
{
    partial class WebMethods
    {
        public static async Task<string> SaveSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await PostAsyncMethod(satinalmaSiparis, "SaveSatinalmaSiparis");
        }
        public static async Task<string> UpdateSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await PostAsyncMethod(satinalmaSiparis, "UpdateSatinalmaSiparis");
        }
        public static string GetFilteredSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return Post(satinalmaSiparis, "GetFilteredSatinalmaSiparis");
        }
        public static async Task<string> DeleteSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis)
        {
            return await PostAsyncMethod(satinalmaSiparis, "DeleteSatinalmaSiparis");
        }
    }
}

