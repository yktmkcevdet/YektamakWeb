namespace Requests
{
    partial class WebMethods
    {
        public async Task<string> GetAllKDV()
        {
            return await GetAsyncMethod("GetAllKDV");
        }
    }
}