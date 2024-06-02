namespace TraktNET
{
    ///<summary>Creates a Trakt POST request.</summary>
    internal sealed class TraktPostRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Post, path)
    {
    }
}
