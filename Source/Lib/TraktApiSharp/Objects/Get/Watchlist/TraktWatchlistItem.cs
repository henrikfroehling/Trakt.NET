namespace TraktApiSharp.Objects.Get.Watchlist
{
    using Attributes;
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using Shows.Seasons;
    using System;

    public class TraktWatchlistItem
    {
        [JsonProperty(PropertyName = "listed_at")]
        public DateTime? ListedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncItemType>))]
        [Nullable]
        public TraktSyncItemType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        [Nullable]
        public TraktSeason Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }
    }
}
