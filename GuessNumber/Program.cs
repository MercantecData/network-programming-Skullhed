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
            Console.WriteLine("Server eller Client");
            string choice = Console.ReadLine();
            string choice1 = choice.ToLower();
            
            if(choice1 == "server"){
                string hostName = Dns.GetHostName();
                string ip = Dns.GetHostByName(hostName).AddressList[1].ToString();
                Console.WriteLine(ip);
                Server server = new Server();
            }else if(choice1 == "client"){
                Client client = new Client();
            }
        }
    }
}
