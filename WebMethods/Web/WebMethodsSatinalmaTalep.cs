using Models;

namespace Requests
{
    public partial class WebMethods
    {
        public string GetTalepTipleri()
        {
			return Get("GetTalepTipleri");
		}
        public static string SaveSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
        {
            return Post(satinalmaTalepBaslik, "SaveSatinalmaTalep");
        }
		public static async Task<string> GetSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
		{
			return await PostAsyncMethod(satinalmaTalepBaslik, "GetSatinalmaTalep");
		}
        public static async Task<string> DeleteSatinalmaTalep(SatinalmaTalepBaslik satinalmaTalepBaslik)
        {
            return await DeleteAsyncMethod(satinalmaTalepBaslik, "DeleteSatinalmaTalep");
        }
        public static string GetFilteredSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay)
        {
            return Post(satinalmaTalepDetay, "GetFilteredSatinalmaTalepDetay");
        }
        public static string SaveSatinalmaTeklifTalep(List<SatinalmaTalepDetay> satinalmaTalepDetayList)
        {
            return Post(satinalmaTalepDetayList, "SaveSatinalmaTeklifTalep");
        }
    }
}
