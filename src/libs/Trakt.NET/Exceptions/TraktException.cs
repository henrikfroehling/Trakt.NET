namespace TraktNET
{
    /// <summary>Base class for all Trakt.NET exceptions.</summary>
    public class TraktException(string message, Exception? innerException = null)
        : Exception(message, innerException)
    {
    }
}
