using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService
{
    partial class WebMethods
    {
        public static async Task<string> SaveErrorLog(ErrorLog errorLog)
        {
            return await PostAsyncMethod(errorLog,"SaveErrorLog");
        }
    }
}
