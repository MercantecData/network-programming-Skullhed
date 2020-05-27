using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            server server = new server();
            
        }
        
    }
    
    public class server
    {
        public server()
        {
            int port = 420;
            IPAddress ip = IPAddress.Any;
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(endpoint);

            listener.Start();

            Console.WriteLine("Awaiting Clients");

            TcpClient client = listener.AcceptTcpClient();

            NetworkStream stream = client.GetStream();
            RecMes(stream);

            Console.WriteLine("Write mes");
            while (true)
            {
                string text = Console.ReadLine();
                byte[] bytes = Encoding.UTF8.GetBytes(text);

                stream.Write(bytes, 0, bytes.Length);
            }
        }
        public async void RecMes(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numb = await stream.ReadAsync(buffer, 0, buffer.Length);
            string mes = Encoding.UTF8.GetString(buffer, 0, numb);

            Console.WriteLine("\n" + mes);
        }
    }
}
