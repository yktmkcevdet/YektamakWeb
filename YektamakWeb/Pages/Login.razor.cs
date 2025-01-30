using ApiService;
using Models;
using Utilities.Common;

namespace YektamakWeb.Pages
{
    public partial class Login
    {
        bool newPasswordMode = false;
        private string userName = default!;
        private string password = default!;
        private string? message;
       
    
        
        //[Inject]
        //LoginHandler _loginHandler { get; set; } = default!;
        
        //private async Task LoginProceduresAsync()
        //{
        //    if (!CheckFields()) return;

        //    Kullanici user = await FetchUserFromDatabase(userName);
        //    if (user == null)
        //    {
        //        dialog.Content = "Kullanıcı bulunamadı.";
        //        dialog?.ShowDialog();
        //        return;
        //    }

        //    if (!VerifyPassword(user, user.sifre))
        //    {
        //        dialog.Content = "Kullanıcı adı veya şifre hatalı.";
        //        dialog?.ShowDialog();
        //        return;
        //    }

        //    var token = _loginHandler.GenerateJwtToken(user);

        //    // Çerezi ekle
        //    //_httpContextAccessor.HttpContext?.Response.Cookies.Append("AuthToken", token, new CookieOptions
        //    //{
        //    //    HttpOnly = true,
        //    //    Secure = true,
        //    //    SameSite = SameSiteMode.Lax,
        //    //    Expires = DateTime.UtcNow.AddMinutes(30)
        //    //});

        //    // Oturum bilgisini güncelle
        //    var userSession = _contextAccessor.HttpContext?.RequestServices.GetRequiredService<UserSession>();
        //    if (userSession != null)
        //    {
        //        userSession.UserName = user.ad;
        //        userSession.IsLoggedIn = true;
        //        userSession.Role = user.rolId.ToString();
        //        userSession.rolId = user.rolId;
        //        userSession.Login();
        //        bool auth=_contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        //    }

        //    // Navigasyonu çerez eklendikten sonra yapın
        //    navigation?.NavigateTo("/proje/");
        //}

        private async Task<Kullanici?> FetchUserFromDatabase(string userName)
        {
            // Kullanıcıyı veritabanından çek
            string jsonString = await WebMethods.GetKullaniciAsync(new Kullanici { ad = userName });
            var dataSet = ConvertHelper.JsonStringToDataSet(jsonString);

            if (dataSet == null || dataSet.Tables[0].Rows.Count == 0)
                return null;

            return ConvertHelper.DataRowToModel<Kullanici>(dataSet.Tables[0].Rows[0]);
        }

        public void InitializeComponentsNewPassword() { }

        public bool VerifyPassword(Kullanici user, string storedHash)
        {
            string hashedPassword = user.sifre;
            return hashedPassword == storedHash;
        }

        private void CreateNewPassword(Kullanici kullanici, string newPassWord)
        {
            string salt = LoginHelper.GenerateSalt();
            string password = newPassWord;
            string hashedPassword = LoginHelper.HashPassword(password, salt);

            kullanici.sifre = hashedPassword;
            kullanici.salt = salt;
            kullanici.isSifreDegisti = true;
            string httpResult = WebMethods.SaveKullanici(kullanici);
            if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                dialog.Content = "Hata oluştu, şifre kaydedilemedi.";
                dialog?.ShowDialog();
            }
        }

        private bool CheckFields()
        {
            bool result = true;
            return result;
        }
    }
}
