using Models;

namespace Requests
{
    partial class WebMethods
	{
		public static async Task<string> GetStokKart(StokKart stokKart=null)
		{
			return await PostAsyncMethod(stokKart, "GetStokKart");
		}
        public static async Task<string> GetStokKartPdf(StokKart stokKart = null)
        {
             return await PostAsyncMethod(stokKart, "GetStokKartPdf");
        }
        public static string SaveStokKart(StokKart stokKart)
		{
			return Post(stokKart, "SaveStokKart");
		}
		public static string GetMalzeme(Malzeme malzeme = null)
		{
			return Post(malzeme, "GetMalzeme");
		}
		public static string SaveMalzeme(Malzeme malzeme)
		{
			return Post(malzeme, "SaveMalzeme");
		}
        public static string GetParcaGrup(ParcaGrup parcaGrup= null)
        {
            return Post(parcaGrup, "GetParcaGrup");
        }
    }
}
