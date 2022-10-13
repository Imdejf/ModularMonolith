using JustCommerce.Modules.BuildingBlocks.Domain;

namespace JustCommerce.Modules.Identity.Domain.User
{
    public class StoreUserRegistrationStatus : ValueObject
    {
        public static StoreUserRegistrationStatus WaitingForConfirmation =>
            new StoreUserRegistrationStatus(nameof(WaitingForConfirmation));

        public static StoreUserRegistrationStatus Confirmed => new StoreUserRegistrationStatus(nameof(Confirmed));

        public static StoreUserRegistrationStatus Expired => new StoreUserRegistrationStatus(nameof(Expired));

        public string Value { get; }

        private StoreUserRegistrationStatus(string value)
        {
            Value = value;
        }
    }
}