using BlazorApp1.Features.Commands.Account.Login;
using Utilities;
using Models;
using Requests;
using Microsoft.AspNetCore.Components;
using System.Data;
using YektamakWeb.Components.Dialogs;
using Microsoft.AspNetCore.Components.Rendering;

namespace YektamakWeb.Pages
{
    public partial class Login
    {
        bool newPasswordMode = false;
        private string userName=default!;
        private string password = default!;
        private string? message;
        [Inject]
        private  IHttpContextAccessor _httpContextAccessor { get; set; }
        [Inject]
        private NavigationManager? navigation { get; set; }
        [Inject]
        LoginHandler _loginHandler { get; set; } = default!;

        private void LoginProcedures()
        {
            if (!CheckFields()) return;
            string storedHashPassword = "";

            Kullanici user = new Kullanici();
            user.ad = userName;
            string jsonString = WebMethods.GetKullanici(user);
            DataSet dataSet = GlobalData.JsonStringToDataSet(jsonString);
            if (dataSet != null)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    storedHashPassword = dataSet.Tables[0].Rows[0]["sifre"].ToString() ?? "";
                    user.Id = int.Parse(dr["Id"].ToString() ?? "");
                    user.salt = dr["salt"].ToString() ?? "";
                    user.sifre = GlobalData.HashPassword(password, user.salt);
                    user.personel = new Personel();
                    user.personel.personelId = int.Parse(dr["personelId"].ToString() ?? "");
                    user.personel.mail = dr["Mail"].ToString() ?? "";
                    user.rolId = int.Parse(dr["rolId"].ToString() ?? "");
                    user.isSifreDegisti = int.TryParse(dr["IsSifreDegisti"].ToString(), out int isSifreDegistiInt)
                                ? isSifreDegistiInt == 1
                                : false;
                }
            }
            else
            {
                dialog.Content = jsonString;
                dialog?.ShowDialog();
            }
            if (VerifyPassword(user, storedHashPassword))
            {
                if (user.isSifreDegisti == false && newPasswordMode == false)
                {
                    InitializeComponentsNewPassword();

                }
                else if (newPasswordMode == true)
                {
                    if (CheckFields())
                    {
                        string newPass = "";
                        CreateNewPassword(user, newPass);
                        OpenMainMenu(user);
                    }
                }
                else if (newPasswordMode == false)
                {
                    var token = _loginHandler.GenerateJwtToken(user);
                    var userSession = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<UserSession>();
                    userSession.UserName = user.ad;
                    userSession.IsLoggedIn = true;
                    userSession.Role = user.rolId.ToString();
                    userSession.rolId = user.rolId;
                    userSession.Login();
                    OpenMainMenu(user);
                }
            }
            else
            {
                dialog.Content = "Kullanıcı Adı ya da Şifre hatalı";
                dialog?.ShowDialog();
            }

        }


        public void InitializeComponentsNewPassword()
        {
        }
        public bool VerifyPassword(Kullanici user, string storedHash)
        {
            string hashedPassword = user.sifre;
            return hashedPassword == storedHash;
        }
        private void CreateNewPassword(Kullanici kullanici, string newPassWord)
        {
            string salt = GlobalData.GenerateSalt();
            string password = newPassWord;
            string hashedPassword = GlobalData.HashPassword(password, salt);

            kullanici.sifre = hashedPassword;
            kullanici.salt = salt;
            kullanici.isSifreDegisti = true;
            string httpResult = WebMethods.SaveKullanici(kullanici);
            if (httpResult.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
            }
            else
            {
            }
        }
        private void OpenMainMenu(Kullanici kullanici)
        {
            navigation?.NavigateTo("/Proje/"); // Yönlendirme
        }



        private bool CheckFields()
        {
            bool result = true;
            return result;
        }
    }
}
