namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktRating
    {
        [JsonProperty(PropertyName = "rating")]
        public float Rating { get; set; }

        [JsonProperty(PropertyName = "votes")]
        public int Votes { get; set; }

        [JsonProperty(PropertyName = "distribution")]
        public Dictionary<string, int> Distribution { get; set; }
    }
}
