using System;
using System.Net.Sockets;
using System.Threading;

namespace CacheFramework.Utils
{
    public class CachingSystemConnector
    {
        private static TcpClient tcpClient;
        public string server { get; set; }
        public int port { get; set; }

        public CachingSystemConnector(string _server, int _port)
        {
            //tcpClient = new TcpClient(_server, _port);
            this.server = _server;
            this.port = _port;
        }

        public void Call(string message, out string result)
        {
            tcpClient = new TcpClient(server, port);

            NetworkStream stream = tcpClient.GetStream();

            try
            {
                // Translate the Message into ASCII.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                // Bytes Array to receive Server Response.
                data = new Byte[256];

                // Read the Tcp Server Response Bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);

                result = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                stream.Close();
                tcpClient.Close();
            }
        }
    }
}
