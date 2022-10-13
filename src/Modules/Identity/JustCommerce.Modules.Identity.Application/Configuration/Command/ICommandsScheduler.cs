using JustCommerce.Modules.Identity.Application.Contracts;

namespace JustCommerce.Modules.Identity.Application.Configuration.Command
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}