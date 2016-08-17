using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace DentApp.Security
{
    public class IdentityHelper : IIdentityHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal CreatePrincipal(string Name, string Role, Dictionary<string, string> Claims = null)
        {
            var identity = new ClaimsIdentity("DentAppCookieMiddlewareInstance", Name, Role);

            identity.AddClaim(new Claim("UserName", Name));
            if(Claims != null){
                foreach(var key in Claims.Keys){
                    identity.AddClaim(new Claim(key, Claims[key]));
                }
            }

            return new ClaimsPrincipal(identity);
        }

        public ClaimsPrincipal GetCurrentPrincipal(){
            return _httpContextAccessor.HttpContext.User as ClaimsPrincipal;
        }
    }
}
