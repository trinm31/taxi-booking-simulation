namespace taxi
{
    public abstract class Information
    {
        public abstract string Id { get; set; }
        public abstract string Name{ get; set; }
        public abstract int Phone{ get; set; }
        
        public abstract string ShowInfor();
    }
}