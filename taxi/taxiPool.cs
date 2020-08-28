using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace taxi
{
	public class TaxiPool
	{
		public static List<DriverInformation> driverInfor = new List<DriverInformation>();
		private const int EXPIRED_TIME_IN_MILISECOND = 1200; 
		public int NUMBER_OF_TAXI;

		private static readonly IList<Taxi> available = new List<Taxi>();
		private readonly IList<Taxi> inUse = new List<Taxi>();

		private int count = 0;
		private Boolean waiting_Conflict = false;
		private static TaxiPool instance = null;
		private string name;
		private string id;
		private int phone;
		
		public static TaxiPool GetInstance()
		{
			if (instance == null)
			{
				instance = new TaxiPool();
			}
			else
			{
				Console.WriteLine("This is singleton!");
			}
			return instance;
		}
		public virtual Taxi Taketaxi()
		{
			lock (this)
			{
				Taxi taxi;
				if (available.Count > 0)
				{
					taxi = available[0];
					available.RemoveAt(0);
					inUse.Add(taxi);
					return taxi;
				}
				else if (count == NUMBER_OF_TAXI)
				{
					this.WaitingUntilTaxiAvailable();
					return Taketaxi();
				}
				taxi = this.CreateTaxi();
				inUse.Add(taxi);
				return taxi;
			}
			
		}

		public virtual void Release(Taxi taxi)
		{
			lock (this)
			{
				inUse.Remove(taxi);
				available.Add(taxi);
				Console.WriteLine(taxi.Name + " is free");
			}
		}

		private Taxi CreateTaxi()
		{
			waiting(200); // The time to create a taxi
			Taxi taxi = new Taxi(driverInfor[count].ShowInfor());
			Console.WriteLine(taxi.Name + " is created");
			count++;
			return taxi;
		}

		private void WaitingUntilTaxiAvailable()
		{
			if (waiting_Conflict)
			{
				waiting_Conflict = false ;
				throw new TaxiNotFoundException("No taxi available");
			}
			waiting_Conflict = true;
			waiting(EXPIRED_TIME_IN_MILISECOND);
		}

		private void waiting(int numberOfSecond)
		{
			try
			{
				Thread.Sleep(numberOfSecond);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}
