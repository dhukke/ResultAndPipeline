using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ResultPipeline.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var installers = GetInstallers();
            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }

        private static List<IInstaller> GetInstallers()
            => typeof(Startup).Assembly
                .ExportedTypes
                .Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract
                )
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
    }
}
