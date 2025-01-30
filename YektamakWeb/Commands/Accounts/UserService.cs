using System.Security.Claims;

namespace YektamakWeb.Commands.Accounts
{
    public class UserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string? GetCurrentUsername()
        {
            return _contextAccessor.HttpContext?.User?.Identity?.Name;
        }

        public string GetUserKullanici()
        {
            return _contextAccessor.HttpContext?.User?.Identity.Name;
                
        }
        public bool GetAuth()
        {
            return _contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
