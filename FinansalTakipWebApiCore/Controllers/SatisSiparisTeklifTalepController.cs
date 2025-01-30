using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class SatisSiparisTeklifTalepController
    {
        [HttpPost, Route("api/SaveSatisSiparisTeklifTalep")]
        public string SaveSatisSiparis([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisSiparisTeklifTalep>(restData, DataBaseJobsSatisSiparisTeklifTalep.SaveSatisSiparisTeklifTalep);
        }
        [HttpPost, Route("api/GetFilteredSatisSiparisTeklifTalep")]
        public string GetFilteredSatisSiparisTeklifTalep([FromBody] string restData)
        {
            return GeneralMethods.ResultData<SatisSiparisTeklifTalep>(restData, DataBaseJobsSatisSiparisTeklifTalep.GetFilteredSatisSiparisTeklifTalep);
        }
    }
}
