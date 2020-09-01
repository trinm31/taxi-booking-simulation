namespace taxi
{
    public class DriverInformation: Information
    {
        public DriverInformation(string id, string name, int phone):base(id, name, phone)
        {
        }
        public override string ShowInfor()
        {
            return $"This is driver {Name} phone number {Phone} and id {Id}";
        }
    }
}