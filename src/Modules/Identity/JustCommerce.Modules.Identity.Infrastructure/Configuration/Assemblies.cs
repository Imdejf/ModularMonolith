using JustCommerce.Modules.Identity.Application.Configuration.Command;
using System.Reflection;

namespace JustCommerce.Modules.Identity.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}