using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    public class MarkaController : Controller
    {
        /// <summary>
        /// json formatında İki tablolu bir dataset döner. İlki bütün markaların tablosunu ikincisi bütün altgrupların tablosunu içerir.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/TumMarkaVeAltGruplar/")]
        public string TumMarkaVeAltGruplar()
        {
            string returnValue = "";
            returnValue = DataBaseJobsMarka.GetAllMarkaAndAltGrup();
            return returnValue;
        }

        [HttpGet, Route("api/GetAllMarka/")]
        public string GetAllMarka()
        {
            string returnValue = "";
            try
            {
                returnValue = DataBaseJobsMarka.GetAllMarka();
            }
            catch (Exception ex)
            {
                returnValue = "error2 Serialization error : " + ex.Message;
            }
            return returnValue;
        }
    }
}