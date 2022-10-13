using JustCommerce.Modules.Identity.Application.Contracts;
using JustCommerce.Modules.Identity.Application.Features.Auth.Dto;

namespace JustCommerce.Modules.Identity.Application.Features.Auth.Query.GetUserStory
{
    public class GetUserStoryQuery : QueryBase<UserStoreDto>
    {
        public GetUserStoryQuery(Guid userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }

        public Guid UserRegistrationId { get; }
    }
}
