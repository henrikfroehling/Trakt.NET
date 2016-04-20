namespace TraktApiSharp.Objects.Get.Shows
{
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;

    public class TraktShowCollectionProgress : TraktShowProgress
    {
        [JsonProperty(PropertyName = "last_collected_at")]
        public DateTime LastCollectedAt { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSeasonCollectionProgress> Seasons { get; set; }
    }
}
