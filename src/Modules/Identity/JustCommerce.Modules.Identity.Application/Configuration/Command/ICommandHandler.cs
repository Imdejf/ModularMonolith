using JustCommerce.Modules.Identity.Application.Contracts;
using MediatR;

namespace JustCommerce.Modules.Identity.Application.Configuration.Command
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
