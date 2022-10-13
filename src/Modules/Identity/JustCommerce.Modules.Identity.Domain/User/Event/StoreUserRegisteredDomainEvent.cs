using JustCommerce.Modules.BuildingBlocks.Domain;

namespace JustCommerce.Modules.Identity.Domain.User.Event
{
    public class StoreUserRegisteredDomainEvent : DomainEventBase
    {
        public StoreUserRegistrationId UserRegistrationId { get; }

        public string Login { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }

        public DateTime RegisterDate { get; }

        public string ConfirmLink { get; }
        public StoreUserRegisteredDomainEvent(
            StoreUserRegistrationId userRegistrationId,
            string login,
            string email,
            string firstName,
            string lastName,
            string name,
            DateTime registerDate,
            string confirmLink)
        {
            UserRegistrationId = userRegistrationId;
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            RegisterDate = registerDate;
            ConfirmLink = confirmLink;
        }
    }
}