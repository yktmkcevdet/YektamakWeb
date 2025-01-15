using Models;
using Requests;
using System.Data;
using BlazorBootstrap;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Threading.Tasks;
using Utilities;

namespace YektamakWeb.Services.StokKartService
{
    public class StokKartService : IStokKartService
    {
        public async Task<(IEnumerable<StokKart>, int)> GetStokKarts(GridDataProviderRequest<StokKart> request)
        {
            List<StokKart> stokKartList = new List<StokKart>();
            string jsonString = await WebMethods.GetStokKart(new StokKart());
            DataSet dataSet = GlobalData.JsonStringToDataSet(jsonString);
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                StokKart stokKart = new();
                stokKart.Id = int.Parse(dr["Id"].ToString()??"0");
                stokKart.kod = dr["kod"].ToString()??"";
                stokKart.ad = dr["ad"].ToString()??"";
                stokKart.boyut = dr["boyut"].ToString()??"0";
                stokKartList.Add(stokKart);
            }
            return (stokKartList,stokKartList.Count);
        }
    }
}
