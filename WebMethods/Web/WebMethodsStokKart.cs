using Models;

namespace ApiService
{
    partial class WebMethods
	{
		public static async Task<string> GetStokKartAsync(StokKart stokKart=null)
		{
			return await PostAsyncMethod(stokKart, "GetStokKart");
		}
        public static string GetStokKart(StokKart stokKart = null)
        {
            return Post(stokKart, "GetStokKart");
        }
        public static string GetStokKartPdf(StokKart stokKart = null)
        {
             return Post(stokKart, "GetStokKartPdf");
        }
        public static async Task<string> SaveStokKart(StokKart stokKart)
		{
			return await PostAsyncMethod(stokKart, "SaveStokKart");
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
        public static string GetMalzemeGrup(MalzemeGrup malzemeGrup = null)
        {
            return Post(malzemeGrup, "GetMalzemeGrup");
        }
        public static string GetStokTip(StokTip stokTip = null)
        {
            return Post(stokTip, "GetStokTip");
        }
        public static string GetProfilTip(ProfilTip profilTip = null)
        {
            return Post(profilTip, "GetProfilTip");
        }
        public static string GetOlcuBirim(OlcuBirim olcuBirim = null)
        {
            return Post(olcuBirim, "GetOlcuBirim");
        }
        public static string GetMalzemeStandart(MalzemeStandart malzemeStandart= null)
        {
            return Post(malzemeStandart, "GetMalzemeStandart");
        }
    }
}
