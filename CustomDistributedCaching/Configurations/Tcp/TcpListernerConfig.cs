using CachingDistributedSystem.CacheSystem;
using CachingDistributedSystem.Services.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CachingDistributedSystem.Configurations.Tcp
{
    public class TcpListernerUtil
    {
        public static TcpListener InitialTcpListener(int port, string addr)
        {
            TcpListener server = null;

            IPAddress localAddr = IPAddress.Parse(addr);

            server = new TcpListener(localAddr, port);

            return server;
        }

        public static async Task NetwworkingStartProcessAsync(TcpListener server, Func<RequestModel, Task<object>> ProcessRequest)
        {
            try
            {
                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        string msg = "-Error: Not completed";

                        try
                        {
                            var requestModel = RequestModel.ToRequestModel(data);
                            
                            // Process the data sent by the client.
                            if (requestModel != null)
                            {
                                var result = await ProcessRequest(requestModel);

                                if (result != null)
                                {
                                    msg = $"OK: {result.ToString()}";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            msg = $"-Error: {ex.Message}";

                        }

                        byte[] output = System.Text.Encoding.ASCII.GetBytes(msg);

                        // Send back a response.
                        stream.Write(output, 0, output.Length);
                        Console.WriteLine("Sent: {0}", msg);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

    }
}
