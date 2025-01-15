using Models;

namespace Requests
{
    partial class WebMethods
    {
        public static async Task<string> SaveKrediKarti(KrediKarti krediKarti)
        {
            return await PostAsyncMethod(krediKarti, "SaveKrediKarti");
        }
        public static async Task<string> GetFilteredKrediKarti(KrediKarti krediKarti)
        {
            return await PostAsyncMethod(krediKarti, "GetFilteredKrediKarti");
        }
        public static async Task<string> DeleteKrediKarti(KrediKarti krediKarti)
        {
            return await PostAsyncMethod(krediKarti, "DeleteKrediKarti");
        }
    }
}
