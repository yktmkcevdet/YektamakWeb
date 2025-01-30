using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using BlazorApp1.Features.Commands.Account.Login;

namespace YektamakWeb.Commands.Accounts
{
    public class LoginService
    {
        private readonly CustomAuthStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;

        public LoginService(CustomAuthStateProvider authStateProvider, NavigationManager navigationManager)
        {
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (username == "feti" && password == "feti") // Basit doğrulama, yerine DB kontrolü koyabilirsiniz
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                _authStateProvider.NotifyUserAuthentication(claimsPrincipal);

                // Kullanıcı giriş yaptığında sayfayı yenile


                return true;
            }
            return false;
        }

        public void Logout()
        {
            _authStateProvider.NotifyUserLogout();
            _navigationManager.NavigateTo("/login", forceLoad: true);
        }
    }
}
