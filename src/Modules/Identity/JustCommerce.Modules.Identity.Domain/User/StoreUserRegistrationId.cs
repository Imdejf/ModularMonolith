using JustCommerce.Modules.BuildingBlocks.Domain;

namespace JustCommerce.Modules.Identity.Domain.User
{
    public class StoreUserRegistrationId : TypedIdValueBase
    {
        public StoreUserRegistrationId(Guid value)
            : base(value)
        {
        }
    }
}
