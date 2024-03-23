using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktMovieStatusJsonConverter))]
    public enum TraktMovieStatus
    {
        Unspecified,
        Released,
        InProduction,
        PostProduction,
        Planned,
        Rumored,
        Canceled
    }
}
