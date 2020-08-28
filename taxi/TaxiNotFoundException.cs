using System;

namespace taxi
{
    public class TaxiNotFoundException : Exception
    {
        public TaxiNotFoundException(string message)
        {
            Console.WriteLine(message);
        }
    }
}