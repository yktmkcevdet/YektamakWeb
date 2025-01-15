using Models;
using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using static FinansalTakipWebApiCore.Controllers.GeneralMethods;
namespace FinansalTakipWebApiCore.Controllers
{
    public class ButtonImageController:Controller
    {
        [HttpPost, Route("api/GetButtonImage")]
        public string GetButtonImage([FromBody] string restData)
        {
            return ResultData<ButtonImage>(restData, DataBaseJobsButtonImage.GetButtonImage);
        }
    }
}
