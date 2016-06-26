namespace TraktApiSharp.Objects.Get.Watched
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktWatchedShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktWatchedShowEpisode> Episodes { get; set; }
    }
}
