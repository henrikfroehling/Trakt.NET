namespace TraktNet.Objects.Basic
{
    public interface ITraktError
    {
        string Error { get; set; }

        string Description { get; set; }
    }
}
