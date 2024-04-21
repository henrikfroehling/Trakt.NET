using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    /// <summary>Determines the day of a week.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktDayOfWeekJsonConverter))]
    public enum TraktDayOfWeek
    {
        /// <summary>An invalid weekday.</summary>
        Unspecified,

        /// <summary>The weekday is monday.</summary>
        [TraktEnumMemberJsonValue("Monday")]
        Monday,

        /// <summary>The weekday is tuesday.</summary>
        [TraktEnumMemberJsonValue("Tuesday")]
        Tuesday,

        /// <summary>The weekday is wednesday.</summary>
        [TraktEnumMemberJsonValue("Wednesday")]
        Wednesday,

        /// <summary>The weekday is thursday.</summary>
        [TraktEnumMemberJsonValue("Thursday")]
        Thursday,

        /// <summary>The weekday is friday.</summary>
        [TraktEnumMemberJsonValue("Friday")]
        Friday,

        /// <summary>The weekday is saturday.</summary>
        [TraktEnumMemberJsonValue("Saturday")]
        Saturday,

        /// <summary>The weekday is sunday.</summary>
        [TraktEnumMemberJsonValue("Sunday")]
        Sunday
    }
}
