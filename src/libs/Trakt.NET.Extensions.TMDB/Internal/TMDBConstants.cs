using System.Text.Json;

#if !NET8_0_OR_GREATER
using TraktNET.Utilities.Json;
#endif

namespace TraktNET
{
    internal static class TMDBConstants
    {
        internal static class API
        {
            internal const string BaseURL = "https://api.themoviedb.org/";

            internal const int Version = 3;
        }

        internal static class Json
        {
            internal const string FactoryKey = "tmdb";

#if NET8_0_OR_GREATER
            internal static readonly JsonNamingPolicy NamingPolicy = JsonNamingPolicy.SnakeCaseLower;
#else
            internal static readonly JsonNamingPolicy NamingPolicy = new LowerSnakeCaseJsonNamingPolicy();
#endif

            internal static readonly JsonSerializerOptions JsonOptions = new()
            {
                PropertyNamingPolicy = NamingPolicy
            };
        }
    }
}
