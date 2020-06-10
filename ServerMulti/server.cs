using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class Server{
    public Server(){
        //Connection settings
        int port = 420;
        IPAddress ip = IPAddress.Any;
        IPEndPoint endpoint = new IPEndPoint(ip, port);

        TcpListener listener = new TcpListener(endpoint);

        //Gets the stream made in ClientConnect
        Task<NetworkStream> stream = ClientConnect(listener);
        //Converts stream from above to a normal stream
        NetworkStream stream1 = stream.Result;

        RecMes(stream1);

        while (true)
        {
            System.Console.WriteLine("Started");
            Console.ReadLine();
        }   

    }
    
    public async Task<NetworkStream> ClientConnect(TcpListener listener)
    {
        //start a listener so clients can connect and returns stream
        listener.Start();
        Console.WriteLine("Awaiting Clients");

        TcpClient client = await listener.AcceptTcpClientAsync();

        NetworkStream stream = client.GetStream();
        return stream;
    }

    //Function used to send responde message to client
    public static void ServerMes(NetworkStream stream, string mes)
    {
        byte[] bytes = Encoding.UTF8.GetBytes("Server: " + mes);
        stream.Write(bytes, 0, bytes.Length);
    }
    
    public async void RecMes(NetworkStream stream)
    {
        byte[] buffer = new byte[1000];
        
        while(true){
            int numb = await stream.ReadAsync(buffer, 0, buffer.Length);
            string mes = Encoding.UTF8.GetString(buffer, 0, numb);
            //Reads the message and makes it to a string
            //Takes the string a split it 
            string[] message = mes.Split(" ");
            dict Dict = new dict();

            foreach(var word in message){
                ServerMes(stream, Dict.answer(word));    
            }
        }
    }
}