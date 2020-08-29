namespace taxi
{
    public class DriverInformation: Information
    {
        public override string Id { get; set; }
        public override string Name { get; set; }
        public override int Phone { get; set; }

        public DriverInformation(string id, string name, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }
        public override string ShowInfor()
        {
            return $"This is driver {Name} phone number {Phone} and id {Id}";
        }
    }
}