using Models;


namespace ApiService
{
    public partial class WebMethods
    {
        public static async Task<string> SaveFirma(Firma firma)
        {
            return await PostAsyncMethod(firma, "SaveFirma");
        }
        public static async Task<string> FirmaGuncelle(Firma firma)
        {
            return await PostAsyncMethod(firma, "FirmaGuncelle");
        }
        public static string GetFilteredFirma(Firma firma)
        {
            return Post(firma, "GetFilteredFirma");
        }
        public static string DeleteFirma(Firma firma)
        {
            return Post(firma, "DeleteFirma");
        }
        public static async Task<string> DetayliFirma(Firma firma)
        {
            return await PostAsyncMethod(firma, "DetayliFirma");
        }
        public static async Task<string> FiltrelenmisFirmalar(FiltreFirma filtreFirma)
        {
            return await PostAsyncMethod(filtreFirma, "FiltrelenmisFirmalar");
        }
        public static string GetSektor(Sektor sektor)
        {
            return Post(sektor, "GetSektor");
        }
    }
    [Serializable]
    public class FiltreFirma
    {
        public string filtreUnvan = "";
        public string filtreVergiDairesi = "";
        public string filtreSehir = "";
        public string filtreSektor = "";
    }
}
