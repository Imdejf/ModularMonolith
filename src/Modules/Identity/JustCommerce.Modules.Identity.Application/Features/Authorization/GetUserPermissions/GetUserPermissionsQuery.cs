using JustCommerce.Modules.Identity.Application.Contracts;
using JustCommerce.Modules.Identity.Application.Features.Authorization.Dto;

namespace JustCommerce.Modules.Identity.Application.Features.Authorization.GetUserPermissions
{
    public class GetUserPermissionsQuery : QueryBase<List<UserPermissionDto>>
    {
        public GetUserPermissionsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
