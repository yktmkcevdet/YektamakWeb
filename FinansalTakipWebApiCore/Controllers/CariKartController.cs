using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using static FinansalTakipWebApiCore.Controllers.GeneralMethods;

namespace FinansalTakipWebApiCore.Controllers
{
    public class CariKartController
    {
        [HttpPost,Route("api/SaveCariKart")]
        public string SaveCariKart([FromBody] string restData)
        {
			return ResultData<CariKart>(restData, DataBaseJobsCariKart.SaveCariKart);
        }
        [HttpPost,Route("api/GetFilteredCariKartlar")]
        public string GetFilteredCariKartlar([FromBody] string restData)
        {
			return ResultData<CariKart>(restData, DataBaseJobsCariKart.GetFilteredCariKartlar);
        }
        [HttpPost,Route("api/DeleteCariKart")]
        public string DeleteCariKart([FromBody] string restData)
        {
            return ResultData<CariKart>(restData, DataBaseJobsCariKart.DeleteCariKart);
        }
    }
}
