using System;
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Net;

namespace ServerMulti
{
    class Program
    {
        static void Main(string[] args)
        {
            //Where you choice to run server or client
            Console.WriteLine("Server eller Client");
            string choice = Console.ReadLine();
            string choice1 = choice.ToLower();
            
            if(choice1 == "server"){
                //Finds the name of the server
                string hostName = Dns.GetHostName();
                //Finds the ip of the server
                string ip = Dns.GetHostByName(hostName).AddressList[1].ToString();
                //Prints out the ip to the console
                Console.WriteLine(ip);
                Server server = new Server();
            }else if(choice1 == "client"){
                Client client = new Client();
            }
        }
    }
}
