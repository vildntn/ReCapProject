using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipleEntensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimPrinciple, string claimType)
        {
            var result = claimPrinciple?.FindAll(claimType).Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimPrinciple)
        {
            return claimPrinciple?.Claims(ClaimTypes.Role);
        }
    }
}
