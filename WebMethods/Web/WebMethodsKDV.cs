namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> GetAllKDV()
        {
            return await GetAsyncMethod("GetAllKDV");
        }
    }
}