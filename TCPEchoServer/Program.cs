using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPEchoServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("TCP Server Simple Protocol ");

            int port = 7;

            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"Server started on port {port}");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = Task.Run(() => ClientHandler.HandleClient(client));
            }
        }
    }
}
