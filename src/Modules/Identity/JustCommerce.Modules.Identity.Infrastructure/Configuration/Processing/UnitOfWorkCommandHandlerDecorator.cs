using JustCommerce.Modules.BuildingBlocks.Infrastructure;
using JustCommerce.Modules.Identity.Application.Configuration.Command;
using JustCommerce.Modules.Identity.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Modules.Identity.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityContext _meetingContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            IdentityContext meetingContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _meetingContext = meetingContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase)
            {
                var internalCommand =
                    await _meetingContext.InternalCommands.FirstOrDefaultAsync(
                        x => x.Id == command.Id,
                        cancellationToken: cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await this._unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}