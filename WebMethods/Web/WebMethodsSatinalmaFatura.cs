using Models;

namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> SaveSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return await PostAsyncMethod(satinalmaFatura, "SaveSatinalmaFatura");
        }
        public static string GetFilteredSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return Post(satinalmaFatura, "GetFilteredSatinalmaFatura");
        }
        public static async Task<string> DeleteSatinalmaFatura(SatinalmaFatura satinalmaFatura)
        {
            return await DeleteAsyncMethod(satinalmaFatura, "DeleteSatinalmaFatura");
        }
    }
}
