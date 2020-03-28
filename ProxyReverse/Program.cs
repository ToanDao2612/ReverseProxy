using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener externalRequestsListener = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse("0.0.0.0");
                externalRequestsListener = new TcpListener(localAddr, 13000);
                externalRequestsListener.Start();

                List<Task> clients = new List<Task>(2);
                while (true)
                {
                    var proxyClient = externalRequestsListener.GetNewClient();
                    var generateClientTask = Task.Run(async () =>
                    {
                        using (var clientHandler = new ClientHandler(proxyClient))
                        {
                            await clientHandler.HandleClient();
                        }
                    });

                    clients.Add(generateClientTask);
                    if (clients.Capacity == clients.Count)
                    {
                        var finishedTask = Task.WhenAny(clients).Result;
                        clients.Remove(finishedTask);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                externalRequestsListener.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

    }
}
