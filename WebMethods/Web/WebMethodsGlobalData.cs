namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> GetGlobalData()
        {
            return await GetAsyncMethod("GetGlobalData");
        }
    }
}
