using CachingDistributedSystem.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CachingDistributedSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.WELCOME);

            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<ICacheRepository<string>, InProcessRepository<string>>();
                services.AddSingleton<ICacheService, CacheService>();
                services.AddHostedService<MachineService>();
            });

            if (isService)
            {
                await builder.RunAsServiceAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }

            Console.WriteLine(ApplicationConfig.SHUTDOWN);
            Console.ReadKey();
        }
    }
}
