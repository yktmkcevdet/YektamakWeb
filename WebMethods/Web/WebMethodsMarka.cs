namespace ApiService
{
    partial class WebMethods
    {
        public  async Task<string> TumMarkaVeAltGruplar()
        {
            return await GetAsyncMethod("TumMarkaVeAltGruplar");
        }
        public async Task<string> GetAllMarka()
        {
            return await GetAsyncMethod("GetAllMarka");
        }
    }
}
