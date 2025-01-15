namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> TumMarkaVeAltGruplar()
        {
            return await GetAsyncMethod("TumMarkaVeAltGruplar");
        }
        public static async Task<string> GetAllMarka()
        {
            return await GetAsyncMethod("GetAllMarka");
        }
    }
}
