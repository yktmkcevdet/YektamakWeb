using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Models;


namespace Requests
{
    public partial class WebMethods
    {
        public static string SavePersonel(Personel personel)
        {
            return Post(personel, "SavePersonel");
        }
        public static string DeletePersonel(Personel personel)
        {
            return  Post(personel, "DeletePersonel");
        }
        /// <summary>
        /// FirmaUnvan'ı da ekleyerek firmaId numaralı firmanın tüm personellerini json'a serileştirilmiş dataset nesnesi olarak getirir
        /// </summary>
        /// <param name="personel"></param>
        /// <returns></returns>
        public static string GetPersonel(Personel personel)
        {
            return Post(personel, "GetPersonel");
        }
        public static string GetPersonelResim(PersonelResim personelResim)
        {
            return Post(personelResim, "GetPersonelResim");
        }
        public static async Task<string> GetPersonelAndPicture(Personel personel)
        {
            return await PostAsyncMethod(personel, "spGetPersonelAndPicture");
        }
    }
}
