using FinansalTakipWebApiCore.DatabaseJobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using static FinansalTakipWebApiCore.Controllers.GeneralMethods;

namespace FinansalTakipWebApiCore.Controllers
{
    [ApiController]
    public class KullaniciController
    {
        [HttpPost, Route("api/SaveKullanici")]
        public string SaveKullanici([FromBody] string restData)
        {
			return ResultData<Kullanici>(restData, DatabaseJobsKullanici.SaveKullanici);
		}
        
        [HttpPost, Route("api/GetKullanici")]
        public string GetKullanici([FromBody] string restData)
        {
			return ResultData<Kullanici>(restData, DatabaseJobsKullanici.GetKullanici);
		}

        [HttpPost, Route("api/GetKullaniciYetki")]
        public string GetKullaniciYetki([FromBody] string restData)
        {
			return ResultData<Kullanici>(restData, DatabaseJobsKullanici.GetKullaniciYetki);
		}

        [HttpPost, Route("api/SaveEkran")]
        public string SaveEkran([FromBody] string restData)
        {
			return ResultData<Ekran>(restData, DatabaseJobsKullanici.SaveEkran);
		}

        [HttpPost, Route("api/SaveYetki")]
        public string SaveYetki([FromBody] string restData)
        {
			return ResultData<Yetki>(restData, DatabaseJobsKullanici.SaveYetki);
		}

        [HttpPost, Route("api/DeleteEkran")]
        public string DeleteEkran([FromBody] string restData)
        {
			return ResultData<Ekran>(restData, DatabaseJobsKullanici.DeleteEkran);
		}
        [HttpGet, Route("api/GetMenu")]
        [Authorize]
        public string GetMenu()
        {
            return DatabaseJobsKullanici.GetMenu();
        }
        [HttpPost,Route("api/SaveMenu")]
        public string SaveMenu([FromBody] string restData)
        {
            return ResultData<Menu>(restData, DatabaseJobsKullanici.SaveMenu);
        }
        [HttpPost, Route("api/DeleteMenu")]
        public string DeleteMenu([FromBody] string restData)
        {
            return ResultData<Menu>(restData, DatabaseJobsKullanici.DeleteMenu);
        }
    }
}
