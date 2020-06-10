using System;

namespace Udp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Client eller server");

            string choice = Console.ReadLine();

            if(choice == "client"){
                Client client = new Client();
            }
            else if(choice == "server"){
                Server server = new Server();
            }
        }
    }
}
