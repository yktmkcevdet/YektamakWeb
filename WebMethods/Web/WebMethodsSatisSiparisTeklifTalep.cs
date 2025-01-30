using Models;

namespace ApiService
{
    partial class WebMethods
    {
        public static async Task<string> SaveSatisSiparisTeklifTalep(SatisSiparisTeklifTalep satisSiparisTeklifTalep)
        {
            return await PostAsyncMethod(satisSiparisTeklifTalep, "SaveSatisSiparisTeklifTalep");
        }
        public static string GetSatisSiparisTeklifTalep(SatisSiparisTeklifTalep satisSiparisTeklifTalep)
        {
            return Post(satisSiparisTeklifTalep, "GetFilteredSatisSiparisTeklifTalep");
        }
    }
}
