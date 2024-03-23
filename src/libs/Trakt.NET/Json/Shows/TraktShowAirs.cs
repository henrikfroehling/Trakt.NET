using System.Text.Json.Serialization;

namespace TraktNET
{
    public class TraktShowAirs
    {
        public TraktDayOfWeek? Day { get; set; }

#if NET6_0_OR_GREATER
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly? Time { get; set; }
#else
        public string? Time { get; set; }
#endif

        public string? Timezone { get; set; }
    }
}
