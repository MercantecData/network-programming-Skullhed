using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

public class ClientConnect{
    public string name;
    public TcpClient client;

    public ClientConnect(string name, TcpClient client){
        this.client = client;
        this.name = name;
    }
}

public class Server{
    //public List<TcpClient> clients = new List<TcpClient>();
    public List<ClientConnect> clients = new List<ClientConnect>();
    public Server(){
        int port = 421;
        IPAddress ip = IPAddress.Any;
        IPEndPoint endPoint = new IPEndPoint(ip, port);
        TcpListener listener = new TcpListener(endPoint);
        listener.Start();

        AcceptClients(listener);
        bool Running = true;
        while(Running){
           System.Console.WriteLine("Welcome");
           Console.ReadLine();
        }
    }

    public async void AcceptClients(TcpListener listener){
        bool Running = true;
        byte[] bytes = new byte[1024];
        while(Running){
            TcpClient client =  await listener.AcceptTcpClientAsync();
            NetworkStream stream = client.GetStream();
            int numb = stream.Read(bytes, 0, bytes.Length);
            string name = Encoding.UTF8.GetString(bytes, 0, numb);
            clients.Add(new ClientConnect(name, client));
            System.Console.WriteLine("Welcome: " + name);
            RecMes(client);
        }
    }

    public async void RecMes(TcpClient client){
        byte[] bytes = new byte[1024];
        
        while(true){
            NetworkStream stream = client.GetStream();
            int numb = await stream.ReadAsync(bytes, 0, bytes.Length);
            string mes = Encoding.UTF8.GetString(bytes, 0, numb);
            string Name = "";
            foreach(ClientConnect aClient in clients){
                if(aClient.client == client){
                    Name = aClient.name;
                }
            }
            if(mes.Contains("/")){
                string[] Fahk = mes.Split("/");
                foreach(var word in Fahk){
                    foreach(ClientConnect client1 in clients){
                        if(client1.name == word){
                            TcpClient PrivateClient = client1.client;
                            string MesPrivate = Name + ": " + mes;
                            byte[] PrivateBytes = Encoding.UTF8.GetBytes(MesPrivate);
                            PrivateClient.GetStream().Write(PrivateBytes, 0, PrivateBytes.Length);
                        }
                    }
                }
            }else if(mes.Contains("Change")){
                string[] NewName = mes.Split(":");
                foreach(ClientConnect client2 in clients){
                    if(client2.name == Name){
                        client2.name = NewName[1];
                    }
                }
            }else{
                foreach(ClientConnect clienten in clients){
                    if(Name != clienten.name){
                        string Mes = Name + ": " + mes;
                        byte[] buffer = Encoding.UTF8.GetBytes(Mes);
                        clienten.client.GetStream().Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
    
}