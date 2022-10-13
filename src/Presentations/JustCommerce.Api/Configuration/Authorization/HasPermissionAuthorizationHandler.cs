using JustCommerce.Modules.BuildingBlocks.Application;
using JustCommerce.Modules.Identity.Application.Contracts;
using JustCommerce.Modules.Identity.Application.Features.Authorization.Dto;
using JustCommerce.Modules.Identity.Application.Features.Authorization.GetUserPermissions;
using Microsoft.AspNetCore.Authorization;

namespace JustCommerce.Api.Configuration.Authorization
{
    internal class HasPermissionAuthorizationHandler : AttributeAuthorizationHandler<
        HasPermissionAuthorizationRequirement, HasPermissionAttribute>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IIdentityModule _identityModule;

        public HasPermissionAuthorizationHandler(
            IExecutionContextAccessor executionContextAccessor,
            IIdentityModule identityModule)
        {
            _executionContextAccessor = executionContextAccessor;
            _identityModule = identityModule;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasPermissionAuthorizationRequirement requirement,
            HasPermissionAttribute attribute)
        {
            var permissions = await _identityModule.ExecuteQueryAsync(new GetUserPermissionsQuery(_executionContextAccessor.UserId));

            if (!await AuthorizeAsync(attribute.Name, permissions))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }

        private Task<bool> AuthorizeAsync(string permission, List<UserPermissionDto> permissions)
        {
#if !DEBUG
            return Task.FromResult(true);
#endif
            return Task.FromResult(permissions.Any(x => x.Code == permission));
        }
    }
}