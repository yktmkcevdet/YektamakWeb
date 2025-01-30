using Models;
using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using static Api.Controllers.GeneralMethods;
namespace Api.Controllers
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
