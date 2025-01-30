using Models;

namespace ApiService
{
    partial class WebMethods
    {
        /// <summary>
        /// SiparisId parametresi gönderilerek SatisSiparis kayitlari döndürür.
        /// </summary>
        /// <param name="siparisId"></param>
        /// <returns></returns>
        public static async Task<string> GetSatisSiparisById(SatisSiparis satisSiparis)
        {
            return await PostAsyncMethod(satisSiparis, "GetFilteredSatisSiparis");
        }
        
        /// <summary>
        /// SatisSiparis nesnesini veritabanına kaydeder.
        /// </summary>
        /// <param name="satisSiparis"></param>
        /// <returns></returns>
        public static async Task<string> SaveSatisSiparis(SatisSiparis satisSiparis)
        {
            return await PostAsyncMethod(satisSiparis, "SaveSatisSiparis");
        }
       /// <summary>
       /// SatisSiparis nesnesini siparisId eşleşmesine göre veritabanında günceller
       /// </summary>
       /// <param name="satisSiparis"></param>
       /// <returns></returns>
        public static async Task<string> UpdateSatisSiparis(SatisSiparis satisSiparis)
        {
            return await PostAsyncMethod(satisSiparis, "SaveSatisSiparis");
        }
        /// <summary>
        /// siparisId ile ilişkili olan SatisSiparis kaydını veritabanından siler.
        /// </summary>
        /// <param name="siparisId"></param>
        /// <returns></returns>
        public static async Task<string> DeleteSatisSiparis(SatisSiparis satisSiparis)
        {
            return await PostAsyncMethod(satisSiparis, "DeleteSatisSiparis");
        }
        /// <summary>
        /// SatisSiparis nesnesi ile gönderilen değerlere göre veritabanından SatisSiparis tablosunu filtrelenmiş verileri döndürür.
        /// </summary>
        /// <param name="satisSiparis"></param>
        /// <returns></returns>
        public static string GetFilteredSatisSiparis(SatisSiparis satisSiparis)
        {
            return Post(satisSiparis, "GetFilteredSatisSiparis");
        }
        public static async Task<string> GetFilteredSatisSiparis(Proje projeKod)
        {
            return await PostAsyncMethod(projeKod, "GetFilteredSatisSiparis");
        }

    }
}
