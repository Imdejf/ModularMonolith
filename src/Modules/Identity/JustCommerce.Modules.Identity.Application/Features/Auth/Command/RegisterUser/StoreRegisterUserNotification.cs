using JustCommerce.Modules.BuildingBlocks.Application.Events;
using JustCommerce.Modules.Identity.Domain.User.Event;
using System.Text.Json.Serialization;

namespace JustCommerce.Modules.Identity.Application.Features.Auth.Command.RegisterUser
{
    public class StoreRegisterUserNotification : DomainNotificationBase<StoreUserRegisteredDomainEvent>
    {
        [JsonConstructor]
        public StoreRegisterUserNotification(StoreUserRegisteredDomainEvent domainEvent, Guid id)
            : base(domainEvent, id)
        {
        }
    }
}
