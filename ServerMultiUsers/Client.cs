using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;

public class Client{
    public Client(){
        UdpConnect();
        while(true){
            Console.ReadLine();
        }
    }

    public async void UdpConnect(){
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 420);
        UdpClient client = new UdpClient(endPoint);
        while(true){
            UdpReceiveResult serverudp = await client.ReceiveAsync();

            byte[] bytes = serverudp.Buffer;

            IPAddress ip = serverudp.RemoteEndPoint.Address;

            int port = BitConverter.ToInt32(bytes, 0);
            System.Console.WriteLine(port);

            TcpConnect(ip, port);
        }
    }

    public async void TcpConnect(IPAddress ip, int port){
        TcpClient client = new TcpClient();

        await client.ConnectAsync(ip, port);

        NetworkStream stream = client.GetStream();

        RecMes(stream);
        while(true){
            string text = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            stream.Write(bytes, 0, bytes.Length);
        }
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