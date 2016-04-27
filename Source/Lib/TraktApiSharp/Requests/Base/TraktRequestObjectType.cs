using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests
{
    internal enum TraktRequestObjectType
    {
        Unspecified,
        Movies,
        Shows,
        Seasons,
        Episodes,
        People,
        Comments
    }
}
