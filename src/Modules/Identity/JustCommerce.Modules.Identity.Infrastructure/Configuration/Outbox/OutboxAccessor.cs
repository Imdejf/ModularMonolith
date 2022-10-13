using JustCommerce.Modules.BuildingBlocks.Application.Outbox;

namespace JustCommerce.Modules.Identity.Infrastructure.Configuration.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly IdentityContext _identityContext;

        internal OutboxAccessor(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public void Add(OutboxMessage message)
        {
            _identityContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}