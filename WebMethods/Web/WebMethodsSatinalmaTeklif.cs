using Models;

namespace Requests
{
    public partial class WebMethods
    {
        public static async Task<string> SaveSatinalmaTeklif(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            return await PostAsyncMethod(satinalmaTeklifBaslik, "SaveSatinalmaTeklif");
        }
    }
}
