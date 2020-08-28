namespace taxi
{
    public class DriverInformation: IInformation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public DriverInformation (string id, string name, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }

        public  string ShowInfor()
        {
            return $"This is driver {Name} phone number {Phone} and id {Id}";
        }
    }
}