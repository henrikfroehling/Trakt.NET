namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Episodes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSeasonWatchedProgress : TraktSeasonProgress
    {
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktEpisodeWatchedProgress> Episodes { get; set; }
    }
}
