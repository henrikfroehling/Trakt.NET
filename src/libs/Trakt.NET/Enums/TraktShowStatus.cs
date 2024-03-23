using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktShowStatusJsonConverter))]
    public enum TraktShowStatus
    {
        Unspecified,
        ReturningSeries,
        Continuing,
        InProduction,
        Planned,
        Upcoming,
        Pilot,
        Canceled,
        Ended
    }
}
