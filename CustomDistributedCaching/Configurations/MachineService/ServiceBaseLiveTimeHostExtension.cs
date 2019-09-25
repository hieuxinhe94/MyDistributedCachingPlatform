﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CachingDistributedSystem.Configurations
{
    public static class ServiceBaseLiveTimeHostExtension
    {
        public static IHostBuilder UseServiceBaseLifetime(this
         IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostContext,
            services) => services.AddSingleton<IHostLifetime,
            ServiceBaseLifeTimeConf>());
        }
        public static Task RunAsServiceAsync(this IHostBuilder
        hostBuilder, CancellationToken cancellationToken = default)
        {
            return
            hostBuilder.UseServiceBaseLifetime().Build()

           .RunAsync(cancellationToken);
        }
    }
}
