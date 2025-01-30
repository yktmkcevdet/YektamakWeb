using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Controllers
{
    public class BankaHesabiController:Controller
    {
        private static JsonConverter[] jsonConverters;
        private JsonSerializerSettings jsonSerializerSettings;

        static BankaHesabiController()
        {
            IsoDateTimeConverter converter1 = new IsoDateTimeConverter();
            converter1.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonConverters = new JsonConverter[] { converter1 };
        }

        public BankaHesabiController()
        {
            JsonSerializerSettings settings1 = new JsonSerializerSettings();
            settings1.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings1.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings1.Converters = jsonConverters;
            this.jsonSerializerSettings = settings1;
        }
        [HttpPost, Route("api/SaveBankaHesabi/")]
        public string SaveBankaHesabi([FromBody] string restData)
        {
            return GeneralMethods.ResultData<BankaHesabi>(restData, DataBaseJobsBankaHesabi.SaveBankaHesabi);
        }

        [HttpPost, Route("api/DeleteBankaHesabi/")]
        public string DeleteBankaHesabi([FromBody] string restData)
        {
            return GeneralMethods.ResultData<BankaHesabi>(restData, DataBaseJobsBankaHesabi.DeleteBankaHesabi);
        }

        [HttpPost, Route("api/GetFilteredBankaHesabi/")]
        public string BankaHesaplariGetir([FromBody] string restData)
        {
            return GeneralMethods.ResultData<BankaHesabi>(restData, DataBaseJobsBankaHesabi.GetFilteredBankaHesabi);
        }
    }
}
