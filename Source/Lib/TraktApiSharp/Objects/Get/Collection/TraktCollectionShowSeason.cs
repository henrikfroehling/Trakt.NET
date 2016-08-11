namespace TraktApiSharp.Objects.Get.Collection
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktCollectionShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktCollectionShowEpisode> Episodes { get; set; }
    }
}
