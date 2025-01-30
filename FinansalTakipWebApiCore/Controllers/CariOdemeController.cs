using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Api.Controllers
{
    public class CariOdemeController
    {
        [HttpGet, Route("api/GetCariOdemeComboLists")]
        public string GetCariOdemeComboLists()
        {
            return DatabaseJobsCariOdeme.GetCariOdemeComboLists();
        }
        [HttpPost, Route("api/SaveCariOdeme")]
        public string SaveCariOdeme([FromBody] string restData)
        {
            return GeneralMethods.ResultData<CariOdeme>(restData, DatabaseJobsCariOdeme.SaveCariOdeme);
        }
        [HttpPost, Route("api/GetFilteredCariOdeme")]
        public string GetFilteredCariOdeme([FromBody] string restData)
        {
            return GeneralMethods.ResultData<CariOdeme>(restData, DatabaseJobsCariOdeme.GetFilteredCariOdeme);
        }
        [HttpPost, Route("api/DeleteCariOdeme")]
        public string DeleteCariOdeme([FromBody] string restData)
        {
            return GeneralMethods.ResultData<CariOdeme>(restData, DatabaseJobsCariOdeme.DeleteCariOdeme);
        }
    }
}