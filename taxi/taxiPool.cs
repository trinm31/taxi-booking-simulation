using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace taxi
{
	public class TaxiPool
	{
		public static List<DriverInformation> DriverInfor = new List<DriverInformation>();
		private const int EXPIRED_TIME_MILISECOND = 1200; 
		public int NumberOfTaxi;

		private static readonly IList<Taxi> _available = new List<Taxi>();
		private readonly IList<Taxi> _inUse = new List<Taxi>();

		private int _count = 0;
		private Boolean _waitingConflict = false;
		private static TaxiPool _instance = null;

		private TaxiPool()
		{
		}
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
		public Taxi Taketaxi()
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

		public void Release(Taxi taxi)
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
			Waiting(200); // The time to create a taxi
			Taxi taxi = new Taxi(DriverInfor[_count].ShowInfor());
			Console.WriteLine(taxi.Name + " is created");
			_count++;
			return taxi;
		}

		private void WaitingUntilTaxiAvailable()
		{
			if (_waitingConflict)
			{
				_waitingConflict = false ;
				throw new TaxiNotFoundException("No taxi available");
			}
			_waitingConflict = true;
			Waiting(EXPIRED_TIME_MILISECOND);
		}

		private void Waiting(int numberOfSecond)
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
