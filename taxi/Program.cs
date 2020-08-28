﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace taxi
{
    public class TaxiApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input Number of client");
            int NUM_OF_CLIENT = Convert.ToInt32(Console.ReadLine());
            
            TaxiPool taxiPool = TaxiPool.GetInstance();
            
            List<ClientInformation> clientInfor = new List<ClientInformation>();
            
            Console.WriteLine("Input number of taxi");
            taxiPool.NUMBER_OF_TAXI = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= NUM_OF_CLIENT; i++)
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
            
            for (int i = 1; i <= taxiPool.NUMBER_OF_TAXI; i++)
            {
                Console.WriteLine($"Input driver {i} id: ");
                string id = Console.ReadLine();
			         
                Console.WriteLine($"Input driver {i} name: ");
                string name = Console.ReadLine();
			         
                Console.WriteLine($"Input driver {i} phone: ");
                int phone = Convert.ToInt32(Console.ReadLine());
                DriverInformation driverInformation = new DriverInformation(id,name,phone);
                TaxiPool.driverInfor.Add(driverInformation);
            }

            Console.WriteLine("----------------------------------------------------------");
            
            for (int i = 1; i <= NUM_OF_CLIENT; i++)
            {
                ClientThread client = new ClientThread(taxiPool);
                ThreadStart threadStart = client.Run;
                Thread thread = new Thread(threadStart);
                thread.Name = clientInfor[i-1].ShowInfor();
                thread.Start();
            }
        }
    }
}