using IdentityServer4.Models;
using IdentityServer4.Validation;
using JustCommerce.Modules.Identity.Application.Contracts;
using JustCommerce.Modules.Identity.Application.Features.Authentication;

namespace JustCommerce.Api.Modules.Identity
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IIdentityModule _identityModule;

        public ResourceOwnerPasswordValidator(IIdentityModule identityModule)
        {
            _identityModule = identityModule;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var authenticationResult = await _identityModule.ExecuteCommandAsync(
                new AuthenticateCommand(context.UserName, context.Password));

            if (!authenticationResult.IsAuthenticated)
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    authenticationResult.AuthenticationError);

                return;
            }

            context.Result = new GrantValidationResult(
                authenticationResult.User.Id.ToString(),
                "forms",
                authenticationResult.User.Claims);
        }
    }
}
