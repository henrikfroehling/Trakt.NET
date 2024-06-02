using System.Text.Json.Serialization;

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
        [TraktEnumMember("Monday")]
        Monday,

        /// <summary>The weekday is tuesday.</summary>
        [TraktEnumMember("Tuesday")]
        Tuesday,

        /// <summary>The weekday is wednesday.</summary>
        [TraktEnumMember("Wednesday")]
        Wednesday,

        /// <summary>The weekday is thursday.</summary>
        [TraktEnumMember("Thursday")]
        Thursday,

        /// <summary>The weekday is friday.</summary>
        [TraktEnumMember("Friday")]
        Friday,

        /// <summary>The weekday is saturday.</summary>
        [TraktEnumMember("Saturday")]
        Saturday,

        /// <summary>The weekday is sunday.</summary>
        [TraktEnumMember("Sunday")]
        Sunday
    }
}
