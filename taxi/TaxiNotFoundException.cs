using System;

namespace taxi
{
    public class TaxiNotFoundException : Exception
    {

        private const long serialVersionUID = -6670953536653728443L;

        public TaxiNotFoundException(string message)
        {
            Console.WriteLine(message);
        }
    }
}