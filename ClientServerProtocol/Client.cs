using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class Client{
    public Client(){
        TcpClient client = new TcpClient();

        int port = 421;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPEndPoint endPoint = new IPEndPoint(ip, port);

        client.Connect(endPoint);

        NetworkStream stream = client.GetStream();

        while(true){
            WriteMes(stream);
        }
    }

    public void WriteMes(NetworkStream stream){
        while(true){
            string mes = Console.ReadLine();
            byte[] bytes = new byte[1024];

            bytes[0] = 42; //Message

            //Calculates how long the text is
            int mesLength = Encoding.UTF8.GetByteCount(mes);
            byte[] bytesRep = BitConverter.GetBytes(mesLength);
            for(int m = 0; m < 4; m++)
                bytes[m ++] = bytesRep[m];

            Encoding.UTF8.GetBytes(mes, 0, mesLength, bytesRep, 5);

            stream.Write(bytes, 0, mesLength);
        }
    }
}