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

        Task<NetworkStream> stream = ClientConnect(listener);
        NetworkStream stream1 = stream.Result;

        Random random = new Random();
        int Number = random.Next(0, 2001);
        System.Console.WriteLine(Number);
        while (true)
        {
            RecMes(stream1, Number);
        }   

    }

    public async Task<NetworkStream> ClientConnect(TcpListener listener)
    {
        listener.Start();

        TcpClient client = await listener.AcceptTcpClientAsync();

        NetworkStream stream = client.GetStream();
        string message = "The number is between 0-2000";
        ServerMes(stream, message);
        return stream;
    }

    
    public void ServerMes(NetworkStream stream, string mes)
    {
        byte[] bytes = Encoding.UTF8.GetBytes("Server: " + mes);
        stream.Write(bytes, 0, bytes.Length);
    }
    
    public async void RecMes(NetworkStream stream, int NumbToGuess)
    {
        byte[] buffer = new byte[1000];
        
        bool run = true;

        while(run){
            int numb = await stream.ReadAsync(buffer, 0, buffer.Length);
            string mes = Encoding.UTF8.GetString(buffer, 0, numb);
            int guess;

            bool inttest = Int32.TryParse(mes, out guess);

            if(inttest){
                if (guess != NumbToGuess){
                    if (guess <= NumbToGuess){
                        string higher = "The number is higher";
                        ServerMes(stream, higher);
                    }
                    else if(guess >= NumbToGuess){
                        string lower = "The number is lower";
                        ServerMes(stream, lower);
                    }
                }
                else{
                    string right = "You guess the number";
                    ServerMes(stream, right);
                    run = false;
                }
            }else{
                string error = "It has to be a number";
                ServerMes(stream, error);
            }
        }
    }
}