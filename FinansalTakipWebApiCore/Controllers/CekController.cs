using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FinansalTakipWebApiCore.Controllers
{
    public class CekController
    {
        [HttpPost, Route("api/SaveCek")]
        public string SaveCek([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Cek>(restData, DataBaseJobsCek.SaveCek);
        }
        [HttpPost, Route("api/GetFilteredCek/")]
        public string GetFilteredCek([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Cek>(restData, DataBaseJobsCek.GetFilteredCek);
        }

        [HttpPost, Route("api/DeleteCek")]
        public string DeleteCek([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Cek>(restData, DataBaseJobsCek.DeleteCek);
        }
    }
}
