using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    public class KasaController
    {
        [HttpPost, Route("api/SaveKasa/")]
        public string SaveKasa([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Kasa>(restData, DataBaseJobsKasa.SaveKasa);
        }

        [HttpGet, Route("api/GetKasalar/")]
        public string GetKasalar()
        {
            return DataBaseJobsKasa.GetKasalar();
        }

        [HttpPost, Route("api/GetFilteredKasa/")]
        public string GetFilteredKasa([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Kasa>(restData, DataBaseJobsKasa.GetFilteredKasa);
        }
        [HttpPost,Route("api/DeleteKasa/")]
        public string DeleteKasa([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Kasa>(restData, DataBaseJobsKasa.DeleteKasa);
        }
    }
}
