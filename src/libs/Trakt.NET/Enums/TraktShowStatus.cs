using System.Text.Json.Serialization;
using TraktNET.SourceGeneration.Enums;

namespace TraktNET
{
    /// <summary>Determines the status of a show.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktShowStatusJsonConverter))]
    public enum TraktShowStatus
    {
        /// <summary>An invalid status.</summary>
        Unspecified,

        /// <summary>The status for a show, which continues.</summary>
        ReturningSeries,

        /// <summary>The status for a show, which continues.</summary>
        Continuing,

        /// <summary>The status for a show, which is in production.</summary>
        InProduction,

        /// <summary>The status for a show, which is planned.</summary>
        Planned,

        /// <summary>The status for a show, which is upcoming.</summary>
        Upcoming,

        /// <summary>The status for a show, which is not yet picked up to serie.</summary>
        Pilot,

        /// <summary>The status for a show, which was canceled.</summary>
        Canceled,

        /// <summary>The status for a show, which has ended.</summary>
        Ended
    }
}
