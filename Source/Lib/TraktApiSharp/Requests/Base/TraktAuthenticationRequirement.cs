using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests
{
    internal enum TraktAuthenticationRequirement
    {
        Required,
        NotRequired,
        Optional
    }
}
