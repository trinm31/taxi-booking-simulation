using System;
using System.Collections.Generic;
using System.Threading;
using taxi;

namespace ProtoType
{
    internal class Program
    {
        public static void Main(string[] args)
        {Console.WriteLine("Input Number of client");
            int numOfClient = Convert.ToInt32(Console.ReadLine());
            
            List<ClientInformation> clientInfor = new List<ClientInformation>();
            List<DriverInformation> DriverInfor = new List<DriverInformation>();
            
            Console.WriteLine("Input number of taxi");
            int numOfTaxi = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= numOfClient; i++)
            {
                Console.WriteLine($"Input client {i} id: ");
                string id = Console.ReadLine();
			         
                Console.WriteLine($"Input client {i} name: ");
                string name = Console.ReadLine();
			         
                Console.WriteLine($"Input client {i} phone: ");
                int phone = Convert.ToInt32(Console.ReadLine());
                
                ClientInformation clientInformation = new ClientInformation(id,name,phone);
                clientInfor.Add(clientInformation);
            }
            
            for (int i = 1; i <= numOfTaxi; i++)
            {
                Console.WriteLine($"Input driver {i} id: ");
                string id = Console.ReadLine();
			         
                Console.WriteLine($"Input driver {i} name: ");
                string name = Console.ReadLine();
			         
                Console.WriteLine($"Input driver {i} phone: ");
                int phone = Convert.ToInt32(Console.ReadLine());
                
                DriverInformation driverInformation = new DriverInformation(id,name,phone);
                DriverInfor.Add(driverInformation);
            }

            Console.WriteLine("----------------------------------------------------------");
            
            for (int i = 1; i <= numOfClient; i++)
            {
                Taxi taxi = new Taxi(DriverInfor[0].ShowInfor());
                Taxi taxicopy = taxi.Clone();
                taxicopy.Name = DriverInfor[i].ShowInfor();
                string client = clientInfor[i - 1].ShowInfor();
                Console.WriteLine($"Taxi: {taxi.Name} serve client: {client}");
            }
        }
    }
}