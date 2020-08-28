namespace taxi
{
    public interface IInformation
    {
        string Id { get; set; }
        string Name{ get; set; }
        int Phone{ get; set; }
        string ShowInfor();
    }
}