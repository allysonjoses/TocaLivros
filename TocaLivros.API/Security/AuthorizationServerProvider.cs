using Microsoft.Owin.Security.OAuth;
using TocaLivros.Domain.Contracts;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace TocaLivros.API.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioRepository _service;

        public AuthorizationServerProvider(IUsuarioRepository service)
        {
            _service = service;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = await _service.GetAsync(context.UserName);

                if (user == null)
                {
                    context.SetError("invalid_grant", "Error Credencial");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("Exception", ex.Message);
            }
        }

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}