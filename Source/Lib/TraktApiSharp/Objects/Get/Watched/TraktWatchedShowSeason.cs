namespace TraktApiSharp.Objects.Get.Watched
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktWatchedShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktWatchedShowEpisode> Episodes { get; set; }
    }
}
