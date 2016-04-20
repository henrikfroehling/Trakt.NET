namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Episodes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSeasonCollectionProgress : TraktSeasonProgress
    {
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktEpisodeCollectionProgress> Episodes { get; set; }
    }
}
