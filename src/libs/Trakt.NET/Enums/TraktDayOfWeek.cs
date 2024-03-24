using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktDayOfWeekJsonConverter))]
    public enum TraktDayOfWeek
    {
        Unspecified,

        [TraktEnumMemberJsonValue("Monday")]
        Monday,

        [TraktEnumMemberJsonValue("Tuesday")]
        Tuesday,

        [TraktEnumMemberJsonValue("Wednesday")]
        Wednesday,

        [TraktEnumMemberJsonValue("Thursday")]
        Thursday,

        [TraktEnumMemberJsonValue("Friday")]
        Friday,

        [TraktEnumMemberJsonValue("Saturday")]
        Saturday,

        [TraktEnumMemberJsonValue("Sunday")]
        Sunday
    }
}
