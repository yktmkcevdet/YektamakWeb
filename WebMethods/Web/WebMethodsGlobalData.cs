namespace ApiService
{
    partial class WebMethods
    {
        public async Task<string> GetGlobalData()
        {
            return await GetAsyncMethod("GetGlobalData");
        }
    }
}
