using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Api.Controllers
{
    public class PersonelController:Controller
    {
        private static JsonConverter[] jsonConverters;
        private JsonSerializerSettings jsonSerializerSettings;

        static PersonelController()
        {
            IsoDateTimeConverter converter1 = new IsoDateTimeConverter();
            converter1.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonConverters = new JsonConverter[] { converter1 };
        }

        public PersonelController()
        {
            JsonSerializerSettings settings1 = new JsonSerializerSettings();
            settings1.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings1.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings1.Converters = jsonConverters;
            this.jsonSerializerSettings = settings1;
        }

        [HttpPost, Route("api/SavePersonel/")]
        public string SavePersonel([FromBody]string restData)
        {
            return GeneralMethods.ResultData<Personel>(restData, DataBaseJobsPersonel.SavePersonel);
        }

        [HttpPost, Route("api/DeletePersonel/")]
        public string DeletePersonel([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Personel>(restData, DataBaseJobsPersonel.DeletePersonel);
        }

        [HttpPost, Route("api/GetPersonel/")]
        public string GetPersonel([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Personel>(restData,DataBaseJobsPersonel.GetPersonel);
        }

        [HttpPost, Route("api/GetPersonelResim/")]
        public string GetPersonelResim([FromBody] string restData)
        {
            return GeneralMethods.ResultData<PersonelResim>(restData, DataBaseJobsPersonel.GetPersonelResim);
        }

        [HttpPost, Route("api/GetPersonelAndPicture/")]
        public string GetPersonelAndPicture([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Personel>(restData, DataBaseJobsPersonel.GetPersonelAndPicture);
        }
    }
}
