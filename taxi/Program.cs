﻿using System;
using System.Threading;

namespace taxi
{
    public class TaxiApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input Number of client");
            int numOfClient = Convert.ToInt32(Console.ReadLine());
            
            TaxiPool taxiPool = TaxiPool.GetInstance();
            
            Console.WriteLine("Input number of taxi");
            taxiPool.NumberOfTaxi = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= numOfClient; i++)
            {
                Console.WriteLine($"Input client {i} id: ");
                string id = Console.ReadLine();
			         
                Console.WriteLine($"Input client {i} name: ");
                string name = Console.ReadLine();
			         
                Console.WriteLine($"Input client {i} phone: ");
                int phone = Convert.ToInt32(Console.ReadLine());
                
                ClientInformation clientInformation = new ClientInformation(id,name,phone);
                Client.clientInfor.Add(clientInformation);
            }
            
            for (int i = 1; i <= taxiPool.NumberOfTaxi; i++)
            {
                Console.WriteLine($"Input driver {i} id: ");
                string id = Console.ReadLine();
			         
                Console.WriteLine($"Input driver {i} name: ");
                string name = Console.ReadLine();
			         
                Console.WriteLine($"Input driver {i} phone: ");
                int phone = Convert.ToInt32(Console.ReadLine());
                
                DriverInformation driverInformation = new DriverInformation(id,name,phone);
                Taxi.DriverInfor.Add(driverInformation);
            }

            Console.WriteLine("----------------------------------------------------------");
            
            for (int i = 1; i <= numOfClient; i++)
            {
                Client client = new Client(taxiPool);
                ThreadStart threadStart = client.TakeATaxi;
                Thread thread = new Thread(threadStart);
                thread.Name = Client.clientInfor[i-1].ShowInfor();
                thread.Start();
            }
        }
    }
}