using System;
using System.Collections.Generic;

namespace CachingDistributedSystem
{
    /// <summary>
    /// CacheRepository
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class InProcessRepository<TItem> : ICacheRepository<TItem>
    {
        // Very Simple in-process memory
        public static Dictionary<object, TItem> _cache = new Dictionary<object, TItem>();

        public InProcessRepository()
        {
            _cache = new Dictionary<object, TItem>();
        }

        public TItem Get(object key)
        {
            if (_cache.ContainsKey(key))
            {
                return _cache[key];
            }

            return default(TItem);
        }

        public void Remove(object key)
        {
            _cache.Remove(key);
        }

        public void Set(object key, TItem value)
        {
            _cache.Add(key, value);
        }
    }
}
