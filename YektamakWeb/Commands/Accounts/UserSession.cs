using Models;
using System.Data;
using Utilities;
using Requests;
namespace BlazorApp1.Features.Commands.Account.Login
{
    public class UserSession
    {
        private readonly IWebMethods _webMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IWebMethods webMethods, IHttpContextAccessor httpContextAccessor)
        {
            _webMethods = webMethods;
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
            DataSet dataSetGlobalData = GlobalData.JsonStringToDataSet( _webMethods.Get("GetGlobalData"));
            anaMenuList = dataSetGlobalData.Tables[9]
            .Select($"rolId={rolId}")
            .Select(dr => new Menu
            {
                menuId = int.Parse(dr["menuId"]?.ToString() ?? "0"),
                menuAdi = dr["menu"]?.ToString() ?? "",
                icon = dr["Icon"]?.ToString() ?? ""
            })
            .ToList();

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
