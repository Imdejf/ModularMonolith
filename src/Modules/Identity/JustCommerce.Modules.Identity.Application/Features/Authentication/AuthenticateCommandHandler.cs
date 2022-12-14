using JustCommerce.Modules.Identity.Application.Contracts;

namespace JustCommerce.Modules.Identity.Application.Features.Authentication
{
    public class AuthenticateCommand : CommandBase<AuthenticationResult>
    {
        public AuthenticateCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }

        public string Password { get; }
    }
}
