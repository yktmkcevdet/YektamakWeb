using FinansalTakipWebApiCore.DatabaseJobs;
using Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FinansalTakipWebApiCore.Controllers
{
	public class GeneralMethods
	{
		public static string ResultData<T>(string restData, Func<T, string> job) where T : class
		{
			if (restData[0] != '\"')
			{
				restData = "\"" + restData;
			}

			if (restData[restData.Length - 1] != '\"')
			{
				restData = restData + "\"";
			}
			byte[] bytes = JsonConvert.DeserializeObject<byte[]>(restData);
			string json = Encoding.UTF8.GetString(bytes);
			var entity = JsonConvert.DeserializeObject<T>(json);
			string result = job(entity);
			return result;
		}
	}
}
