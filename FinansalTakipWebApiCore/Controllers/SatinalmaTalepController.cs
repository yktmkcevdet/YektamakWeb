using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using static FinansalTakipWebApiCore.Controllers.GeneralMethods;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatinalmaTalepController:Controller
    {
        [HttpGet,Route("api/GetTalepTipleri")]
        public string GetTalepTipleri()
        {
            return DatabaseJobsSatinalmaTalep.GetTalepTipleri();
        }
		[HttpPost, Route("api/SaveSatinalmaTalep")]
		public string SaveSatinalmaTalep([FromBody] string restData)
		{
			return ResultData<SatinalmaTalepBaslik>(restData, DatabaseJobsSatinalmaTalep.SaveSatinalmaTalep);
		}
		[HttpPost, Route("api/GetSatinalmaTalep")]
		public string GetSatinalmaTalep([FromBody] string restData)
		{
			return ResultData<SatinalmaTalepBaslik>(restData, DatabaseJobsSatinalmaTalep.GetSatinalmaTalep);
		}
        [HttpPost, Route("api/DeleteSatinalmaTalep")]
        public string DeleteSatinalmaTalep([FromBody] string restData)
        {
            return ResultData<SatinalmaTalepBaslik>(restData, DatabaseJobsSatinalmaTalep.DeleteSatinalmaTalep);
        }
        [HttpPost, Route("api/GetFilteredSatinalmaTalepDetay")]
        public string GetFilteredSatinalmaTalepDetay([FromBody] string restData)
        {
            return ResultData<SatinalmaTalepDetay>(restData, DatabaseJobsSatinalmaTalep.GetFilteredSatinalmaTalepDetay);
        }
        [HttpPost, Route("api/SaveSatinalmaTeklifTalep")]
        public string SaveSatinalmaTeklifTalep([FromBody] string restData)
        {
            return ResultData<List<SatinalmaTalepDetay>>(restData, DatabaseJobsSatinalmaTalep.SaveSatinalmaTeklifTalep);
        }
    }
}
