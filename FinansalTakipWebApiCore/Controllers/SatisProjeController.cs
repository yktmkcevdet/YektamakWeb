using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FinansalTakipWebApiCore.Controllers
{
    public class SatisProjeController:Controller
    {
        [HttpPost, Route("api/SaveSatisProje/")]
        public string SaveSatisProje([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisProje>(restData, DataBaseJobsSatisProje.SaveSatisProje);
        }

        [HttpPost, Route("api/GetFilteredSatisProje/")]
        public string GetFilteredSatisProje([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisProje>(restData, DataBaseJobsSatisProje.GetFilteredSatisProje);
        }

        [HttpPost, Route("api/DeleteSatisProje/")]
        public string DeleteSatisProje([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisProje>(restData, DataBaseJobsSatisProje.DeleteSatisProje);
        }
    }
}
