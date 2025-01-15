using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace FinansalTakipWebApiCore.Controllers
{
    public class AnaVeriController : Controller
    {
        [HttpGet, Route("api/GetParcaGrupList/")]
        public string GetParcaGrupList()
        {
            return DataBaseJobsAnaVeri.GetParcaGrupList();
        }
        [HttpGet, Route("api/GetParcaAltGrupList/")]
        public string GetParcaAltGrupList()
        {
            return DataBaseJobsAnaVeri.GetParcaAltGrupList();
        }
    }
}
