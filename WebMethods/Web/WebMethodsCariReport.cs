namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> GetCariHesapEkstresi()
        {
            return await GetAsyncMethod("GetCariHesapEkstresi");
        }
    }
}
