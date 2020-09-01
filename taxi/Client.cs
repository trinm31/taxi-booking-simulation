using System;
using System.Collections.Generic;
using System.Threading;

namespace taxi
{
    public class Client
    {
        public static List<ClientInformation> clientInfor = new List<ClientInformation>();
        private TaxiPool _taxiPool;

        public Client(TaxiPool taxiPool)
        {
            this._taxiPool = taxiPool;
        }

        
        public void TakeATaxi()
        {
            try
            {
                Console.WriteLine("New client: " + Thread.CurrentThread.Name);
                Taxi taxi = _taxiPool.Taketaxi();

                Thread.Sleep(RandInt(1000, 1500));

                _taxiPool.Release(taxi);
                
                Console.WriteLine("Served the client: " + Thread.CurrentThread.Name);
            }
            catch (Exception e) 
            {
                Console.WriteLine(">>>Rejected the client: " + Thread.CurrentThread.Name);
            }
        }

        public int RandInt(int min, int max)
        {
            return (new Random()).Next((max - min) + 1) + min;
        }
    }
}