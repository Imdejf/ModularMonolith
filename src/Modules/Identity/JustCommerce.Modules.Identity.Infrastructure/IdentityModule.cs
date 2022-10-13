using Autofac;
using JustCommerce.Modules.Identity.Application.Contracts;
using JustCommerce.Modules.Identity.Infrastructure.Configuration;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Processing;
using MediatR;

namespace JustCommerce.Modules.Identity.Infrastructure
{
    public class IdentityModule : IIdentityModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = IdentityCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}