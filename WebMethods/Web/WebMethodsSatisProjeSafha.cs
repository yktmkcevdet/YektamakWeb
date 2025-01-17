using Models;

namespace Requests
{
    public partial class WebMethods
    {
        public static async Task<string> SaveSatisProjeSafha(SatisProje satisProje)
        {
            return await PostAsyncMethod(satisProje, "SaveSatisProjeSafhaList");
        }
        public static async Task<string> DeleteSatisProjeSafha(ProjeSafha projeSafha)
        {
            return await PostAsyncMethod(projeSafha, "DeleteSatisProjeSafha");
        }
        public static async Task<string> GetSatisProjeSafhaList(SatisProje satisProje)
        {
            return await PostAsyncMethod(satisProje, "GetSatisProjeSafhaList");
        }
        public async Task<string> GetProjeAsamaTanimlari()
        {
            return await GetAsyncMethod("GetProjeAsamaTanimlari");
        }
    }
}
