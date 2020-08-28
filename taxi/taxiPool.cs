using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace taxi
{
	public class TaxiPool
	{
		public static List<DriverInformation> driverInfor = new List<DriverInformation>();
		private const int ExpiredTimeInMilisecond = 1200; 
		public int NumberOfTaxi;

		private static readonly IList<Taxi> _available = new List<Taxi>();
		private readonly IList<Taxi> _inUse = new List<Taxi>();

		private int _count = 0;
		private Boolean waiting_Conflict = false;
		private static TaxiPool _instance = null;

		public static TaxiPool GetInstance()
		{
			if (_instance == null)
			{
				_instance = new TaxiPool();
			}
			else
			{
				Console.WriteLine("This is singleton!");
			}
			return _instance;
		}
		public virtual Taxi Taketaxi()
		{
			lock (this)
			{
				Taxi taxi;
				if (_available.Count > 0)
				{
					taxi = _available[0];
					_available.RemoveAt(0);
					_inUse.Add(taxi);
					return taxi;
				}
				else if (_count == NumberOfTaxi)
				{
					this.WaitingUntilTaxiAvailable();
					return Taketaxi();
				}
				taxi = this.CreateTaxi();
				_inUse.Add(taxi);
				return taxi;
			}
			
		}

		public virtual void Release(Taxi taxi)
		{
			lock (this)
			{
				_inUse.Remove(taxi);
				_available.Add(taxi);
				Console.WriteLine(taxi.Name + " is free");
			}
		}

		private Taxi CreateTaxi()
		{
			waiting(200); // The time to create a taxi
			Taxi taxi = new Taxi(driverInfor[_count].ShowInfor());
			Console.WriteLine(taxi.Name + " is created");
			_count++;
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
			waiting(ExpiredTimeInMilisecond);
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
