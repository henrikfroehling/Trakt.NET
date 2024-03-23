namespace TraktNET
{
    public interface ITraktIds
    {
        bool HasAnyID { get; }

        string BestID { get; }
    }
}
