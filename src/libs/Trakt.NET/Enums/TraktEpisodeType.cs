using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    /// <summary>Determines the type of an episode.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktEpisodeTypeJsonConverter))]
    public enum TraktEpisodeType
    {
        /// <summary>An invalid episode type.</summary>
        Unspecified,

        /// <summary>The type for a standard episode.</summary>
        Standard,

        /// <summary>The type for a series premiere episode (season 1, episode 1).</summary>
        SeriesPremiere,

        /// <summary>The type for a season premiere episode (episode 1).</summary>
        SeasonPremiere,

        /// <summary>The type for a mid season finale episode.</summary>
        MidSeasonFinale,

        /// <summary>The type for a mid season premiere episode (the next episode after the mid season finale).</summary>
        MidSeasonPremiere,

        /// <summary>The type for a season finale episode.</summary>
        SeasonFinale,

        /// <summary>The type for a series finale episode (last episode to air for an ended show).</summary>
        SeriesFinale
    }
}
