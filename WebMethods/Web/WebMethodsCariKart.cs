using Models;

namespace Requests
{
    partial class WebMethods
    {
        public static string SaveCariKart(CariKart cariKart)
        {
			return Post(cariKart, "SaveCariKart");
        }
        public static string GetFilteredCariKartlar(CariKart cariKart)
        {
			return Post(cariKart, "GetFilteredCariKartlar");
        }
        public static async Task<string> DeleteCariKart(CariKart cariKart)
        {
			return await PostAsyncMethod(cariKart, "DeleteCariKart");
        }
    }
}
