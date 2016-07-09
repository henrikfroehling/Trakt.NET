namespace TraktApiSharp.Objects.Get.Collection
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktCollectionSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktCollectionEpisode> Episodes { get; set; }
    }
}
