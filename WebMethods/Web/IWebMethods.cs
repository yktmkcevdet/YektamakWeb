using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requests
{
    public interface IWebMethods
    {
        public Task<string> GetAsyncMethod(string apiAdres);
        public string Get(string apiAdres);
    }
}
