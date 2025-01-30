using Api.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
