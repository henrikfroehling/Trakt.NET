namespace TraktNET
{
    public interface ITraktContext
    {
        string ID { get; }

        Uri BaseUri { get; }
    }
}
