using Models;

namespace Requests
{
    partial class WebMethods
    {
        public string GetCariOdemeComboLists()
        {
            return Get("GetCariOdemeComboLists");
        }
        public static async Task<string> SaveCariOdeme(CariOdeme cariOdeme)
        {
            return await PostAsyncMethod(cariOdeme, "SaveCariOdeme");
        }
        public static string GetFilteredCariOdeme(CariOdeme cariOdeme)
        {
            return Post(cariOdeme, "GetFilteredCariOdeme");
        }
        public static string DeleteCariOdeme(CariOdeme cariOdeme)
        {
            return Post(cariOdeme, "DeleteCariOdeme");
        }
    }
}
