using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
 
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Book.Api.Authentication
{
	public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		public CustomAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
		{
		}

		public string ProblemDetailsContentType { get; private set; }

		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{

			//check  Request.Headers. against api key
			//

		


			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, "kusnadi")
			};
			var identity = new ClaimsIdentity(claims, "Key");
			var identities = new List<ClaimsIdentity> { identity };
			var principal = new ClaimsPrincipal(identities);

			var ticket = new AuthenticationTicket(principal, "Key");

			return Task.FromResult(AuthenticateResult.Success(ticket));
		}



	}
}
