using CacheFramework.Utils;
using System.Text;

namespace CacheFramework.Repository
{
    public class CacheRepository : ICacheRepository
    {
        private ICacheOption _option;
        private CachingSystemConnector connector;
        public CacheRepository(ICacheOption option)
        {
            this._option = option;
            connector = new CachingSystemConnector(_option.ServerName, _option.Port);
        }

        public byte[] GetByKey(string keyName)
        {
            string message = $"GET {keyName}";
            connector.Call(message, out string result);

            return Encoding.ASCII.GetBytes(result);
        }

        public void RemoveKey(string key)
        {
            string message = $"REMOVE {key}";

            connector.Call(message, out _);
        }

        public void SetValue(string key, byte[] val)
        {
            string message = $"SET {key} {Encoding.ASCII.GetString(val)}";
            connector.Call(message, out _);
        }
    }
}
