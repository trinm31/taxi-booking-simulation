namespace taxi
{
    public class ClientInformation: Information
    {
        
        public ClientInformation(string id, string name, int phone):base(id, name, phone)
        {
        }
        public override string ShowInfor()
        {
            return $"This is client {Name} phone number {Phone} and id {Id}";
        }
    }
}