namespace TraktApiSharp.Objects.Shows.Common
{
    using Newtonsoft.Json;

    public class TraktShowsMostAnticipatedItem
    {
        [JsonProperty(PropertyName = "list_count")]
        public int? ListCount { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
