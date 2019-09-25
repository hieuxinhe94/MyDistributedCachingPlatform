namespace CacheFramework.Repository
{
    public interface ICacheRepository
    {
        byte[] GetByKey(string keyName);

        void RemoveKey(string keyName);

        void SetValue(string key, byte[] val);
    }
}
