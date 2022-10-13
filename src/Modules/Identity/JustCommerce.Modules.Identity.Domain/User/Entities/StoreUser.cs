using JustCommerce.Modules.BuildingBlocks.Domain;

namespace JustCommerce.Modules.Identity.Domain.User.Entities
{
    public class StoreUser : Entity, IAggregateRoot
    {
        public StoreUserRegistrationId Id { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }
        private string LastName { get; set; }
        private string Name { get; set; }
        private DateTime DateCreation { get; set; }
        private Guid StoreId { get; set; }
    }
}
