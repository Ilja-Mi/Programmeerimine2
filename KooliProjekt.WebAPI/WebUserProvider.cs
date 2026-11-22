using System.Security.Claims;
using KooliProjekt.Application.Infrastructure;
using Microsoft.AspNetCore.Http;
namespace KooliProjekt.WebAPI
{
    public class WebUserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _accessor;
        public WebUserProvider(IHttpContextAccessor accessor) { _accessor = accessor; }
        public int? UserId()
        {
            var user = _accessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true) return null;
            var value = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(value, out var id) && id > 0 ? id : null;
        }
    }
}
