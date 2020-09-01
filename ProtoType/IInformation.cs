namespace taxi
{
    public abstract class Information
    {
        protected string Id;
        protected string Name;
        protected int Phone;

        public Information(string id, string name, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }
        public abstract string ShowInfor();
    }
}