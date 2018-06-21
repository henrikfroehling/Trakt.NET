namespace TraktNet.Objects.Basic
{
    public interface IIds
    {
        bool HasAnyId { get; }

        string GetBestId();
    }
}
