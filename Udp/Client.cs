using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class Client{
    public Client(){
        UdpClient client = new UdpClient();

        string text = "Bitch";
        byte[] bytes = Encoding.UTF8.GetBytes(text);

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 420);

        client.Send(bytes, bytes.Length, endPoint);
    }
}