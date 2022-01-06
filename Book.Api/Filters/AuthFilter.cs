using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Security.Claims;

namespace Book.Api.Filters
{
	public class AuthFilter : IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "kusnadi")
            };

 

            var identity = new ClaimsIdentity(claims, "ApiKey");
            var identities = new List<ClaimsIdentity> { identity };
            var principal = new ClaimsPrincipal(identities);

            context.HttpContext.User = principal;
        }
	}
}
