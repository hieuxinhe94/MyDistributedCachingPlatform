using System;

namespace CachingDistributedSystem
{
    public interface ICacheRepository<TItem>
    {
        TItem Get(object key);
        void Set(object key, TItem value);
        void Remove(object key);
    }
}
