using Api.DatabaseJobs;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Api.Controllers.GeneralMethods;

namespace Api.Controllers
{
    public class StokKartController
	{
		[HttpPost,Route("api/GetStokKart")]
		public string GetStokKartFilter([FromBody] string restData)
		{
			return ResultData<StokKart>(restData, DatabaseJobsStokKart.GetStokKart);
		}
        [HttpPost, Route("api/GetStokKartPdf")]
        public string GetStokKartPdf([FromBody] string restData)
        {
            return ResultData<StokKart>(restData, DatabaseJobsStokKart.GetStokKartPdf);
        }
        [HttpPost, Route("api/SaveStokKart")]
		public string SaveStokKart([FromBody] string restData)
		{
			return ResultData<StokKart>(restData, DatabaseJobsStokKart.SaveStokKart);
		}
		[HttpPost,Route("api/GetMalzeme")]
		public string GetMalzeme([FromBody] string restData)
		{
			return ResultData<Malzeme>(restData,DatabaseJobsStokKart.GetMalzeme);
		}
		[HttpPost, Route("api/SaveMalzeme")]
		public string SaveMalzeme([FromBody] string restData)
		{
			return ResultData<Malzeme>(restData, DatabaseJobsStokKart.SaveMalzeme);
		}
        [HttpPost, Route("api/GetParcaGrup")]
        public string GetParcaGrup([FromBody] string restData)
        {
            return ResultData<ParcaGrup>(restData, DatabaseJobsStokKart.GetParcaGrup);
        }
        [HttpPost, Route("api/DeleteProjeDosya")]
        public string DeleteProjeDosya([FromBody] string restData)
        {
            return ResultData<Proje>(restData, DatabaseJobsStokKart.DeleteProjeDosya);
        }
        [HttpPost, Route("api/GetMalzemeGrup")]
        public string GetMalzemeGrup([FromBody] string restData)
        {
            return ResultData<MalzemeGrup>(restData, DatabaseJobsStokKart.GetMalzemeGrup);
        }
        [HttpPost, Route("api/GetStokTip")]
        public string GetStokTip([FromBody] string restData)
        {
            return ResultData<StokTip>(restData, DatabaseJobsStokKart.GetStokTip);
        }
        [HttpPost, Route("api/GetProfilTip")]
        public string GetProfilTip([FromBody] string restData)
        {
            return ResultData<ProfilTip>(restData, DatabaseJobsStokKart.GetProfilTip);
        }
        [HttpPost, Route("api/GetOlcuBirim")]
        public string GetOlcuBirim([FromBody] string restData)
        {
            return ResultData<OlcuBirim>(restData, DatabaseJobsStokKart.GetOlcuBirim);
        }
        [HttpPost, Route("api/GetMalzemeStandart")]
        public string GetMalzemeStandart([FromBody] string restData)
        {
            return ResultData<MalzemeStandart>(restData, DatabaseJobsStokKart.GetMalzemeStandart);
        }
    }
}
