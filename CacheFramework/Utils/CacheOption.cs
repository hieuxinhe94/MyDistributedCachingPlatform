namespace CacheFramework.Utils
{
    public class CacheOption : ICacheOption
    {
        public string ServerName { get; set; }
        public int Port { get; set; }

        public CacheOption(string server, int port)
        {
            this.ServerName = server;
            this.Port = port;
        }
    }
}
