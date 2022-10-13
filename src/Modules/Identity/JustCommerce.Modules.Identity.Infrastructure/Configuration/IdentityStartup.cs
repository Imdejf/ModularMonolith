using Autofac;
using JustCommerce.Modules.BuildingBlocks.Application;
using JustCommerce.Modules.BuildingBlocks.Infrastructure;
using JustCommerce.Modules.BuildingBlocks.Infrastructure.EventBus;
using JustCommerce.Modules.Identity.Application.Features.Auth.Command.RegisterUser;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.DataAccess;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Domain;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.EventsBus;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Logging;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Mediator;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Processing;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Processing.Outbox;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Quartz;
using JustCommerce.Modules.Identity.Infrastructure.Configuration.Security;
using Serilog;
using Serilog.AspNetCore;

namespace JustCommerce.Modules.Identity.Infrastructure.Configuration
{
    public class IdentityStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            string textEncryptionKey,
            IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "Identity");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                logger,
                textEncryptionKey,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

            EventsBusStartup.Initialize(moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            string textEncryptionKey,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "UserAccess")));

            var loggerFactory = new SerilogLoggerFactory(logger);

            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();
            domainNotificationsMap.Add("NewUserRegisteredNotification", typeof(StoreRegisterUserNotification));
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            IdentityCompositionRoot.SetContainer(_container);
        }
    }
}