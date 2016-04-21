namespace TraktApiSharp.Objects.Get.Shows
{
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;

    public class TraktShowWatchedProgress : TraktShowProgress
    {
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime LastWatchedAt { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSeasonWatchedProgress> Seasons { get; set; }
    }
}
