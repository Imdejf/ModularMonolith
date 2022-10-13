using JustCommerce.Modules.BuildingBlocks.Application.Outbox;
using JustCommerce.Modules.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace JustCommerce.Modules.Identity.Infrastructure.Configuration
{
    internal class IdentityContext : DbContext
    {
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }


        private readonly ILoggerFactory _loggerFactory;
        public IdentityContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IdentityContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
