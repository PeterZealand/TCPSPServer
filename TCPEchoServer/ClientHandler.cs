using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace TCPEchoServer
{
    public class ClientHandler
    {

        public static void HandleClient(TcpClient client)
        {
            Console.WriteLine(client.Client.RemoteEndPoint);
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            bool IsRunning = true;

            while (IsRunning)
            {
                string message = reader.ReadLine(); //if string allows a null value the server will be spammed and the null check doesnt work?
                if (message == null)
                {
                    // Client has closed the connection
                    break;
                }
                Console.WriteLine(message);
                if (message == "Random")
                {
                    writer.WriteLine("Input numbers");
                    string[] inputs = reader.ReadLine().Split(' ');
                    int num1 = int.Parse(inputs[0]);
                    int num2 = int.Parse(inputs[1]);
                    Console.WriteLine($"Received numbers: {num1}, {num2}");
                    int randomValue = new Random().Next(num1, num2 + 1); // +1 ensures num2 is included
                    writer.WriteLine(randomValue.ToString());
                }
                else if (message == "Add")
                {
                    writer.WriteLine("Input numbers");
                    string[] inputs = reader.ReadLine().Split(' ');
                    int num1 = int.Parse(inputs[0]);
                    int num2 = int.Parse(inputs[1]);
                    Console.WriteLine($"Received numbers: {num1}, {num2}");
                    int Value = num1 + num2;
                    writer.WriteLine(Value.ToString());
                }
                else if (message == "Subtract")
                {
                    writer.WriteLine("Input numbers");
                    string[] inputs = reader.ReadLine().Split(' ');
                    int num1 = int.Parse(inputs[0]);
                    int num2 = int.Parse(inputs[1]);
                    Console.WriteLine($"Received numbers: {num1}, {num2}");
                    int Value = num1 - num2;
                    writer.WriteLine(Value.ToString());
                }
            }
            client.Close();


              //test with using async task
            //public static async Task HandleClient(TcpClient client)
            //{
            //    Console.WriteLine(client.Client.RemoteEndPoint);
            //    NetworkStream ns = client.GetStream();
            //    StreamReader reader = new StreamReader(ns);
            //    StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            //    bool IsRunning = true;

            //    while (IsRunning)
            //    {
            //        string? message = await reader.ReadLineAsync();
            //        Console.WriteLine(message);
            //        if (message == "Random")
            //        {
            //            await writer.WriteLineAsync("Input numbers");
            //            string[] inputs = (await reader.ReadLineAsync()).Split(' ');
            //            int num1 = int.Parse(inputs[0]);
            //            int num2 = int.Parse(inputs[1]);
            //            int randomValue = new Random().Next(num1, num2 + 1); // // +1 ensures num2 is included
            //            await writer.WriteLineAsync(randomValue.ToString());
            //        }
            //        else if (message == "Add")
            //        {
            //            await writer.WriteLineAsync("Input numbers");
            //            string[] inputs = (await reader.ReadLineAsync()).Split(' ');
            //            int num1 = int.Parse(inputs[0]);
            //            int num2 = int.Parse(inputs[1]);
            //            int Value = num1 + num2;
            //            await writer.WriteLineAsync(Value.ToString());
            //        }
            //        else if (message == "Subtract")
            //        {
            //            await writer.WriteLineAsync("Input numbers");
            //            string[] inputs = (await reader.ReadLineAsync()).Split(' ');
            //            int num1 = int.Parse(inputs[0]);
            //            int num2 = int.Parse(inputs[1]);
            //            int Value = num1 - num2;
            //            await writer.WriteLineAsync(Value.ToString());
            //        }
            //    }
            //    client.Close();
        }
    }
}
