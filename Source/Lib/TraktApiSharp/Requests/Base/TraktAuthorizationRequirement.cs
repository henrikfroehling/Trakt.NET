using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests
{
    internal enum TraktAuthorizationRequirement
    {
        Required,
        NotRequired,
        Optional
    }
}
