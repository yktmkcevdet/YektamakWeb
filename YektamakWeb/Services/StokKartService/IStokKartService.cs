using BlazorBootstrap;
using Models;

namespace YektamakWeb.Services.StokKartService
{
    public interface IStokKartService
    {
        public Task<(IEnumerable<StokKart>, int)> GetStokKarts(GridDataProviderRequest<StokKart> request);
    }
}
