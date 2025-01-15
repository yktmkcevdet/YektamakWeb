using Models;

namespace Requests
{
    public partial class WebMethods
    {
        public static string GetFilteredSatisFatura(SatisFatura satisFatura)
        {
            return Post(satisFatura, "GetFilteredSatisFatura");
        } 
        public static async Task<string> SaveSatisFatura(SatisFatura satisFatura)
        {
            return await PostAsyncMethod(satisFatura, "SaveSatisFatura");
        }
        public static async Task<string> GetSatisFaturaById(SatisFatura satisFatura)
        {
            return await PostAsyncMethod(satisFatura, "GetSatisFaturaById");
        }
        public static async Task<string> DeleteSatisFatura(SatisFatura satisFatura)
        {
            return await PostAsyncMethod(satisFatura, "DeleteSatisFatura");
        }
    }
}
