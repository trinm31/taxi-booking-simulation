namespace taxi
{
    public class Taxi
    {

        private string _name;

        public Taxi(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = value;
            }
        }
        
        public override string ToString()
        {
            return "Taxi [name=" + _name + "]";
        }
    }
}