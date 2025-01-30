using ApiService;
using BlazorBootstrap;
using Models;
using System.Data;
using Utilities.Common;

namespace YektamakWeb.Services.StokKartService
{
    public class StokKartService : IStokKartService
    {
        public (IEnumerable<StokKart>, int) GetStokKarts(GridDataProviderRequest<StokKart> request)
        {
            List<StokKart> stokKartList = new List<StokKart>();
            string jsonString = WebMethods.GetStokKart(new StokKart());
            DataSet dataSet = ConvertHelper.JsonStringToDataSet(jsonString);
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
