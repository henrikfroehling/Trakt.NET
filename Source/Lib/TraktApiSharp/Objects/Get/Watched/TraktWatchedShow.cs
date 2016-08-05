namespace TraktApiSharp.Objects.Get.Watched
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;
    using System;
    using System.Collections.Generic;

    public class TraktWatchedShow
    {
        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktWatchedShowSeason> Seasons { get; set; }
    }
}
