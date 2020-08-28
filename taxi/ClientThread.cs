using System;
using System.Collections.Generic;
using System.Threading;

namespace taxi
{

    public class ClientThread
    {
        
        private TaxiPool taxiPool;

        public ClientThread(TaxiPool taxiPool)
        {
            this.taxiPool = taxiPool;
        }

        public void Run()
        {
            takeATaxi();
        }

        private void takeATaxi()
        {
            try
            {
                Console.WriteLine("New client: " + Thread.CurrentThread.Name);
                Taxi taxi = taxiPool.Taketaxi();

                Thread.Sleep(randInt(1000, 1500));

                taxiPool.Release(taxi);
                
                Console.WriteLine("Served the client: " + Thread.CurrentThread.Name);
            }
            catch (Exception e) 
            {
                Console.WriteLine(">>>Rejected the client: " + Thread.CurrentThread.Name);
            }
        }

        public static int randInt(int min, int max)
        {
            return (new Random()).Next((max - min) + 1) + min;
        }
    }
}