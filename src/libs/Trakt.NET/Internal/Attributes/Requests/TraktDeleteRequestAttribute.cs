namespace TraktNET
{
    ///<summary>Creates a Trakt DELETE request.</summary>
    internal sealed class TraktDeleteRequestAttribute(string path) : TraktRequestAttribute(HttpMethod.Delete, path)
    {
    }
}
