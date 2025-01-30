using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Controllers
{
    public class FirmaController : Controller
    {
        private static JsonConverter[] jsonConverters;
        private JsonSerializerSettings jsonSerializerSettings;

        static FirmaController()
        {
            IsoDateTimeConverter converter1 = new IsoDateTimeConverter();
            converter1.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonConverters = new JsonConverter[] { converter1 };
        }

        public FirmaController()
        {
            JsonSerializerSettings settings1 = new JsonSerializerSettings();
            settings1.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings1.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings1.Converters = jsonConverters;
            this.jsonSerializerSettings = settings1;
        }


        [HttpPost, Route("api/SaveFirma/")]
        public string SaveFirma([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Firma>(restData, DataBaseJobsFirma.SaveFirma);
        }


        [HttpPost, Route("api/FirmaGuncelle/")]
        public string FirmaGuncelle([FromBody] string restData)
        {
			return GeneralMethods.ResultData<Firma>(restData, DataBaseJobsFirma.UpdateFirma);
        }

        [HttpPost, Route("api/GetFilteredFirma/")]
        public string GetFilteredFirma([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Firma>(restData, DataBaseJobsFirma.GetFilteredFirma);
		}

        [HttpPost, Route("api/DeleteFirma/")]
        public string DeleteFirma([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Firma>(restData, DataBaseJobsFirma.DeleteFirma);
        }

        [HttpPost, Route("api/DetayliFirma/")]
        public string DetaylıFirma([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Firma>(restData, DataBaseJobsFirma.GetDetailedFirmaFromFirmaId);
        }
    }
}