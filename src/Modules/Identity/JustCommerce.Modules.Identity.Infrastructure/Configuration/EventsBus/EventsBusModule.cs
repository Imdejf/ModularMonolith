using Autofac;
using JustCommerce.Modules.BuildingBlocks.EventBus;
using JustCommerce.Modules.BuildingBlocks.Infrastructure.EventBus;

namespace JustCommerce.Modules.Identity.Infrastructure.Configuration.EventsBus
{
    internal class EventsBusModule : Module
    {
        private readonly IEventsBus _eventsBus;

        public EventsBusModule(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_eventsBus != null)
            {
                builder.RegisterInstance(_eventsBus).SingleInstance();
            }
            else
            {
                builder.RegisterType<InMemoryEventBusClient>()
                    .As<IEventsBus>()
                    .SingleInstance();
            }
        }
    }
}