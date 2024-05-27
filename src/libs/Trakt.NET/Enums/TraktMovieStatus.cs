using System.Text.Json.Serialization;
using TraktNET.SourceGeneration.Enums;

namespace TraktNET
{
    /// <summary>Determines the status of a movie.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktMovieStatusJsonConverter))]
    public enum TraktMovieStatus
    {
        /// <summary>An invalid status.</summary>
        Unspecified,

        /// <summary>The status for a movie, which is released.</summary>
        Released,

        /// <summary>The status for a movie, which is in production.</summary>
        InProduction,

        /// <summary>The status for a movie, which is in post production.</summary>
        PostProduction,

        /// <summary>The status for a movie, which is planned.</summary>
        Planned,

        /// <summary>The status for a movie, which is rumored.</summary>
        Rumored,

        /// <summary>The status for a movie, which is canceled.</summary>
        Canceled
    }
}
