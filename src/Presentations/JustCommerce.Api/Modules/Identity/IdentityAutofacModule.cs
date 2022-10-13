using Autofac;
using JustCommerce.Modules.Identity.Application.Contracts;
using JustCommerce.Modules.Identity.Infrastructure;

namespace JustCommerce.Api.Modules.Identity
{
    internal sealed class IdentityAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityModule>()
                .As<IIdentityModule>()
                .InstancePerLifetimeScope();
        }
    }
}
