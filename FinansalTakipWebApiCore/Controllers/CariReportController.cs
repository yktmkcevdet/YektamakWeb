using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CariReportController
    {
        [HttpGet, Route("api/GetCariHesapEkstresi")]
        public string GetCariHesapEkstresi()
        {
            string returnValue = "";
            try
            {
                returnValue = DatabaseJobsCariReport.GetCariHesapEkstresi();
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
    }
}
