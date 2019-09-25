using CacheFramework.Repository;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CachingDistributedSystem.CacheFramework
{
    public class CachingFramework : IDistributedCache
    {
        private ICacheRepository _cacheRepository;

        public CachingFramework(ICacheRepository cacheRepository)
        {
            this._cacheRepository = cacheRepository;
        }

        public byte[] Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return new byte[0];
            }

            return _cacheRepository.GetByKey(key);
        }

        public Task<byte[]> GetAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Refresh(string key)
        {
            throw new NotImplementedException();
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                _cacheRepository.RemoveKey(key);
            }
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                // TODO: Handle the option
                _cacheRepository.SetValue(key, value);
            }
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
