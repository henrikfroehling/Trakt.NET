namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Newtonsoft.Json;

    public class TraktMostAnticipatedShow
    {
        [JsonProperty(PropertyName = "list_count")]
        public int? ListCount { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
