﻿using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace FinansalTakipWebApiCore.Controllers
{
    public class GorevController
    {
        [HttpPost, Route("api/GetFilteredGorev/")]
        public string GetFilteredGorev([FromBody] string restData)
        {
            return GeneralMethods.ResultData<Gorev>(restData, DatabaseJobsGorev.GetFilteredGorev);
        }
    }
}
