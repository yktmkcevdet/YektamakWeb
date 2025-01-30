using Models;

namespace ApiService
{
    public partial class WebMethods
    {        
        public static async Task<string> SaveSatisProje(SatisProje satisProje)
        {
            return await PostAsyncMethod(satisProje, "SaveSatisProje");
        }
        public static string GetFilteredSatisProje(SatisProje satisProje)
        {
            return Post(satisProje, "GetFilteredSatisProje");
        }
        public static async Task<string> DeleteSatisProje(SatisProje satisProje)
        {
            return await PostAsyncMethod(satisProje, "DeleteSatisProje");
        }
    }
}