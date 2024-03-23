using System.Globalization;
using System.Text.Json.Serialization;

namespace TraktNET
{
    public class TraktSeasonIds : ITraktIds
    {
        public uint? Trakt { get; set; }

        public uint? TVDB { get; set; }

        public uint? TMDB { get; set; }

        [JsonIgnore]
        public bool HasAnyID => Trakt.HasValue && Trakt.Value > 0 || TVDB.HasValue && TVDB.Value > 0 || TMDB.HasValue && TMDB.Value > 0;

        [JsonIgnore]
        public string BestID
        {
            get
            {
                if (!HasAnyID)
                    return string.Empty;

                if (Trakt.HasValue && Trakt.Value > 0)
                    return Trakt.Value.ToString(CultureInfo.InvariantCulture);

                if (TVDB.HasValue && TVDB.Value > 0)
                    return TVDB.Value.ToString(CultureInfo.InvariantCulture);

                if (TMDB.HasValue && TMDB.Value > 0)
                    return TMDB.Value.ToString(CultureInfo.InvariantCulture);

                return string.Empty;
            }
        }
    }
}
