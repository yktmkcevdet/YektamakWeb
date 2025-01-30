using BlazorBootstrap;
using Models;

namespace YektamakWeb.Services.StokKartService
{
    public interface IStokKartService
    {
        public (IEnumerable<StokKart>, int) GetStokKarts(GridDataProviderRequest<StokKart> request);
    }
}
