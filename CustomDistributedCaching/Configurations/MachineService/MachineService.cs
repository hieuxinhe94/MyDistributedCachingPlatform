using CachingDistributedSystem.Configurations.Tcp;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace CachingDistributedSystem.Configurations
{
    public class MachineService : IHostedService, IDisposable
    {
        private ICacheService _cacheService;

        public MachineService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StartAsync");

            TcpListener server = TcpListernerUtil.InitialTcpListener(ApplicationConfig.SERVICE_PORT,ApplicationConfig.SERVICE_NAME);

            _ = TcpListernerUtil.NetwworkingStartProcessAsync(server, async (model) => await _cacheService.Handler(model));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StopAsync");
            return Task.CompletedTask;
        }
    }
}
