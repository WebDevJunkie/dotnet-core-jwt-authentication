using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotnetCoreJWTAuthentication.Helpers
{
    public static class IHttpContextAccessorExtension
    {
        public static int CurrentUser(this IHttpContextAccessor httpContextAccessor)
        {
            var type = JwtRegisteredClaimNames.Jti;
            var stringId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            int.TryParse(stringId ?? "0", out int userId);

            return userId;
        }
    }
}
