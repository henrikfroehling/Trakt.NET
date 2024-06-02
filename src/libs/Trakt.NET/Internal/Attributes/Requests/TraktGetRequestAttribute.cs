namespace TraktNET
{
    ///<summary>Creates a Trakt GET request.</summary>
    internal sealed class TraktGetRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Get, path)
    {
    }
}
