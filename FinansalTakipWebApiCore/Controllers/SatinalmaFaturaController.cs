using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    public class SatinalmFaturaController : Controller
    {
        [HttpPost,Route("api/SaveSatinalmaFatura")]
        public string SaveSatinalmaFatura([FromBody] string restData)
        {
            return ResultData<SatinalmaFatura>(restData, DataBaseJobsSatinalmaFatura.SaveSatinalmaFatura);
        }

        [HttpPost, Route("api/UpdateSatinalmaFatura")]
        public string UpdateSatinalmaFatura([FromBody] string restData)
        {
            return ResultData<SatinalmaFatura>(restData, DataBaseJobsSatinalmaFatura.SaveSatinalmaFatura);
        }

        [HttpPost,Route("api/GetFilteredSatinalmaFatura")]
        public string GetSatinalmaFatura([FromBody] string restData)
        {
            return ResultData<SatinalmaFatura>(restData, DataBaseJobsSatinalmaFatura.GetFilteredSatinalmaFatura);
        }

        [HttpPost, Route("api/DeleteSatinalmaFatura")]
        public string DeleteSatinalmaFatura([FromBody] string restData)
        {
            return ResultData<SatinalmaFatura>(restData, DataBaseJobsSatinalmaFatura.DeleteSatinalmaFatura);
        }
    }
}
