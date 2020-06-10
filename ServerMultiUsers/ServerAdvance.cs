using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;

public class UDP{

    public List<int> ports = new List<int>();
    public UDP(){
        ports.Add(5001);
        ports.Add(420);
        ports.Add(5000);
        UdpPorts();

        while(true){
            System.Console.WriteLine("Started");
            Server server = new Server();
            Console.ReadLine();
        }
    }

    public void UdpPorts(){
        UdpClient client = new UdpClient();

        int ClientConnect = 421;
        byte[] bytes = BitConverter.GetBytes(ClientConnect);

        foreach(int Int in ports){
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), Int);
                client.Send(bytes, bytes.Length, endPoint);
        }
    }
}