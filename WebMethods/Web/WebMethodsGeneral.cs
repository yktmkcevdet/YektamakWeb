using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Requests.Constants;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace Requests
{
    public partial class WebMethods:IWebMethods
	{
        private static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        private static HttpClient client = new HttpClient(handler);
        static JsonConverter[] jsonConverters = new JsonConverter[] { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } };
        static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Converters = jsonConverters
        };
        public static string Post<T>(T entity, string apiAdres) where T : class
		{
            client.DefaultRequestHeaders.Clear();

            string postString = JsonConvert.SerializeObject(entity, jsonSerializerSettings);
			byte[] data = Encoding.UTF8.GetBytes(postString);
			postString = JsonConvert.SerializeObject(data, jsonSerializerSettings);

			var response = client.PostAsync(ApiBaseUrl.server + "/api/" + apiAdres, new StringContent(postString, Encoding.UTF8, "application/json"));
			var responseData = response.Result;
			string result = responseData.Content.ReadAsStringAsync().Result;
			return result;
		}
		public static async Task<string> PostAsyncMethod<T>(T entity, string apiAdres) where T : class
		{
			try
			{
                client.DefaultRequestHeaders.Clear();

                string postString = JsonConvert.SerializeObject(entity, jsonSerializerSettings);
                byte[] data = Encoding.UTF8.GetBytes(postString);
                postString = JsonConvert.SerializeObject(data, jsonSerializerSettings);

                string url = ApiBaseUrl.server + "/api/" + apiAdres;
                var content = new StringContent(postString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var strResponse = response.Content.ReadAsStringAsync();
                strResponse.Wait();
                string returnValue = strResponse.Result;
                return strResponse.Result;
            }
			catch(Exception e)
			{
				return e.InnerException.ToString();
			}
			
		}
		public async Task<string> GetAsyncMethod(string apiAdres)
		{
			client.DefaultRequestHeaders.Clear();

			string url = ApiBaseUrl.server + "/api/" + apiAdres;
			var response = await client.GetAsync(url);
			var strResponse = response.Content.ReadAsStringAsync();
			strResponse.Wait();
			string returnValue = strResponse.Result;
			return strResponse.Result;
		}
        public string Get(string apiAdres)
        {
            client.DefaultRequestHeaders.Clear();
            string url = ApiBaseUrl.server + "/api/" + apiAdres;
            var response = client.GetAsync(url);
            var responseData = response.Result;
            string result = responseData.Content.ReadAsStringAsync().Result;
            return result;
        }
        public static async Task<string> DeleteAsyncMethod<T>(T entity,string apiAdres)
		{
            client.DefaultRequestHeaders.Clear();

			string postString = JsonConvert.SerializeObject(entity, jsonSerializerSettings);
			byte[] data = Encoding.UTF8.GetBytes(postString);
			postString = JsonConvert.SerializeObject(data, jsonSerializerSettings);

			string url = ApiBaseUrl.server + "/api/" + apiAdres;
			var content = new StringContent(postString, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(url, content);
			var strResponse = response.Content.ReadAsStringAsync();
			strResponse.Wait();
			string returnValue = strResponse.Result;
			return strResponse.Result;
		}
	}
}
