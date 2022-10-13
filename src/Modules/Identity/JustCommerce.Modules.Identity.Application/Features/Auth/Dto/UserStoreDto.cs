namespace JustCommerce.Modules.Identity.Application.Features.Auth.Dto
{
    public sealed class UserStoreDto
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string StatusCode { get; set; }
    }
}
