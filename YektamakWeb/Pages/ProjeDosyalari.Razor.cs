using Models;
using Requests;
using Microsoft.AspNetCore.Components;
using System.Data;
using Utilities;

namespace YektamakWeb.Pages
{
    partial class ProjeDosyalari
    {
        public List<StokKart> stokKarts = new List<StokKart>();
        private string message;
        private int selectedProjeId;
        [Inject]
        private NavigationManager? navigation { get; set; }
        private async Task GetProjeDosyalari()
        {
            try
            {
                // API çağrısı yap
                StokKart stokKart = new StokKart();
                stokKart.proje.Id = selectedProjeId;
                string serializeString = await WebMethods.GetStokKart(stokKart);
                DataSet dataSet = GlobalData.JsonStringToDataSet(serializeString);
                if (dataSet != null)
                {
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        stokKart = GlobalData.DataRowToModel<StokKart>(dataRow);
                        stokKarts.Add(stokKart);
                    }
                }
            }
            catch (Exception ex)
            {
                message = $"Veri çekme hatası: {ex.Message}";
            }
        }

        public void PdfGoster(StokKart stokKart)
        {
            message = stokKart.ad;
            navigation?.NavigateTo($"/PdfViewer/{stokKart.Id}");
        }
    }
}
