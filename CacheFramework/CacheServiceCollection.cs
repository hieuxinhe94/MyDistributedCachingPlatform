using CacheFramework.Repository;
using CacheFramework.Utils;
using CachingDistributedSystem.CacheFramework;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace CacheFramework
{
    public static class CacheServiceCollection
    {
        public static void AddCachingFramework(this IServiceCollection services)
        {
            // TODO: Using func => option
            services.AddSingleton<ICacheOption>(o => new CacheOption("127.0.0.1", 6789));
            services.AddSingleton<ICacheRepository, CacheRepository>();
            services.AddSingleton<IDistributedCache, CachingFramework>();
        }
    }
}
