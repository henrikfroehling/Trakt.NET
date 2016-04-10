namespace TraktApiSharp.Objects.Shows.Common
{
    using Newtonsoft.Json;

    public class TraktShowsTrendingItem
    {
        [JsonProperty(PropertyName = "watchers")]
        public int? Watchers { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
