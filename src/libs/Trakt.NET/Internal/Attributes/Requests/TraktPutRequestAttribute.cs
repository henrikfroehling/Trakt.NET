namespace TraktNET
{
    ///<summary>Creates a Trakt PUT request.</summary>
    internal sealed class TraktPutRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Put, path)
    {
    }
}
