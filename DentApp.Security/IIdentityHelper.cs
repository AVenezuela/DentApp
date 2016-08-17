using System.Collections.Generic;
using System.Security.Claims;

namespace DentApp.Security
{
    public interface IIdentityHelper
    {
        ClaimsPrincipal CreatePrincipal(string Name, string Role, Dictionary<string, string> Claims = null);
        ClaimsPrincipal GetCurrentPrincipal();
    }
}
