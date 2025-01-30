namespace ApiService
{
    partial class WebMethods
    {
        public async Task<string> GetCariHesapEkstresi()
        {
            return await GetAsyncMethod("GetCariHesapEkstresi");
        }
    }
}
