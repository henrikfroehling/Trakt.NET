using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktEpisodeTypeJsonConverter))]
    public enum TraktEpisodeType
    {
        Unspecified,
        Standard,
        SeriesPremiere,
        SeasonPremiere,
        MidSeasonFinale,
        MidSeasonPremiere,
        SeasonFinale,
        SeriesFinale
    }
}
