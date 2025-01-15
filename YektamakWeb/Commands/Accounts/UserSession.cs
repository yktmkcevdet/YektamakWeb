using Models;
using System.Data;
using Utilities;
using Requests;
namespace BlazorApp1.Features.Commands.Account.Login
{
    public class UserSession
    {
        public List<Menu> anaMenuList = new List<Menu>();
        public int Id { get; set; }
        public int rolId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public event Action? OnChange;
        public bool IsLoggedIn { get; private set; }
        public async void Login(string userName)
        {
            IsLoggedIn = true;
            UserName = userName;
            DataSet dataSetGlobalData = GlobalData.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            foreach (DataRow dr in dataSetGlobalData.Tables[9].Select($"rolId={rolId}"))
            {
                Menu menu = new();
                menu.menuId = int.Parse(dr["menuId"].ToString()??"");
                menu.menuAdi = dr["menu"].ToString() ?? "";
                menu.icon = dr["Icon"].ToString() ?? "";
                anaMenuList.Add(menu);
            }
            
            NotifyStateChanged();
        }

        public void Logout()
        {
            IsLoggedIn = false;
            UserName = string.Empty;
            
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }

}
