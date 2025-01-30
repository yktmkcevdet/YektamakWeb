using Models;
using System.Data;
using Utilities;
using ApiService;
using NPOI.HSSF.Record;
namespace BlazorApp1.Features.Commands.Account.Login
{
    public class UserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Menu> anaMenuList { get; private set;}=new();
        public int Id { get; set; }
        public int rolId { get; set; }
        public string? UserName;
        public string Role { get; set; }
        public event Action? OnChange;
        public bool IsLoggedIn;
        public void Login()
        {
            //DataSet dataSetGlobalData = Utilities.Common.ConvertHelper.JsonStringToDataSet( WebMethods.Get("GetGlobalData"));
            //anaMenuList = dataSetGlobalData.Tables[9]
            //.Select($"rolId={rolId}")
            //.Select(dr => new Menu
            //{
            //    Id = int.Parse(dr["Id"]?.ToString() ?? "0"),
            //    ad = dr["ad"]?.ToString() ?? "",
            //    icon = dr["icon"]?.ToString() ?? ""
            //})
            //.ToList();  
            
            NotifyStateChanged();
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }

}
