using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Client
{
    public Client()
    {
        TcpClient client = new TcpClient();

        Console.WriteLine("Port:");
        int port = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ip:");
        string ipaddress = Console.ReadLine();
        IPAddress ip = IPAddress.Parse(ipaddress);
        IPEndPoint endpoint = new IPEndPoint(ip, port);

        client.Connect(endpoint);

        NetworkStream stream = client.GetStream();
        RecMes(stream);
        while (true)
        {
            WriteMes(stream);
        }
            
    }

    public async void WriteMes(NetworkStream stream)
    {
        string text = Console.ReadLine();
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        await stream.WriteAsync(bytes, 0, bytes.Length);
    }

    public async void RecMes(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];

        while(true){
            int numb = await stream.ReadAsync(buffer, 0, buffer.Length);
            string mes = Encoding.UTF8.GetString(buffer, 0, numb);
            Console.WriteLine("\n" + mes);
        }
    }
}