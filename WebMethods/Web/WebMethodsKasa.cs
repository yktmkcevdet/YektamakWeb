using Models;

namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> SaveKasa(Kasa kasa)
        {
            return await PostAsyncMethod(kasa, "SaveKasa");
        }
        public static async Task<string> UpdateKasa(Kasa kasa)
        {
            return await PostAsyncMethod(kasa, "UpdateKasa");
        }
        public static string DeleteKasa(Kasa kasa)
        {
            return Post(kasa, "DeleteKasa");
        }
        public async Task<string> GetKasalar()
        {
            return await GetAsyncMethod("GetKasalar");
        }
        public static string GetFilteredKasa(IKasa kasa)
        {
            return Post(kasa, "GetFilteredKasa");
        }
    }
}
