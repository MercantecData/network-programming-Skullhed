using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class Server{
    public Server(){
        RecMes();
        Console.ReadLine();
    }

    public async void RecMes(){
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 420);
        UdpClient client = new UdpClient(endPoint);

        while(true){
            UdpReceiveResult mes = await client.ReceiveAsync();

            byte[] bytes = mes.Buffer;

            string text = Encoding.UTF8.GetString(bytes);

            System.Console.WriteLine(text);
        }
    }
}