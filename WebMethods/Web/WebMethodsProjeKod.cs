using System.Text;
using Models;
using Newtonsoft.Json;
using System.Data;
using Requests.Constants;

namespace Requests
{
    public partial class WebMethods
    {
        public static string MaxProjeNo(Proje proje)
        {
            return Post(proje, "MaxProjeNo");
        }

        /// <summary>
        /// projeKod'u veri tabanına kaydeder. Sonuçlar şu şekilde anlam taşır;
        /// >0 : Sorunsuz bir şekilde kayıt gerçekleşti. Geri dönen değer yeni kaydın id numarası.
        /// -1 : Server hatası (server içerisinde (veritabanı vs ile ilgili) oluşan bir hata)
        /// -2 : Bağlantı hatası (timeout olması, client bağlantısı veya server'a erişimle ilgili bir hata)
        /// -3 : Aynı proje numarası daha önce kayıt edilmiş
        /// </summary>
        /// <param name="projeKod"></param>
        /// <returns></returns>
        public static async Task<string> ProjeKodKaydet(Proje projeKod)
        {
            return await PostAsyncMethod(projeKod, "ProjeKodKaydet");
        }
        /// <summary>
        /// SatisProje tablosunda firmaID sütunu boş olan kayıtları getirir.
        /// </summary>
        /// <returns></returns>
        public string GetAllUnassignedProjeKod()
        {
            return Get("UnassignedProjeKod");
        }
        /// <summary>
        /// SatisProje tablosunda firmaID sütunu boş olmayan olan kayıtları getirir.
        /// </summary>
        /// <returns></returns>
        public string GetAllAssignedProjeKod()
        {
            return Get("GetAllAssignedProjeKod");
        }
        /// <summary>
        /// ProjeKodId parametresi ile ProjeKod nesnesini döndürür
        /// </summary>
        /// <param name="projeKodId"></param>
        /// <returns></returns>
        public static async Task<string> GetProjeKodById(Proje proje)
        {
            return Post(proje,"GetProjeKodById");
        }
        /// <summary>
        /// Satış siparişi açılmış projelerin listesini döndürür.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAllOrderedProjeKod()
        {
            return await GetAsyncMethod("GetAllOrderedProjeKod");
        }
        public static string GetProjeKodByUserId(Proje proje)
        {
            return Post(proje, "GetProjeKodByUserId");
        }
        public static async Task<string> DeleteProjeDosya(Proje proje)
        {
            return await PostAsyncMethod(proje, "DeleteProjeDosya");
        }
    }

    
}

