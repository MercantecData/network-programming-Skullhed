using System;

namespace ServerMultiUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = Console.ReadLine();

            if(choice == "Server" || choice == "server"){
                UDP uDP = new UDP();
            }else if(choice == "Client" || choice == "client"){
                Client client = new Client();
            }
        }
    }
}
