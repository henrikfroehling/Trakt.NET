namespace TraktApiSharp.Objects
{
    using Enums;
    using Newtonsoft.Json;

    public class TraktGenre
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonIgnore]
        public TraktGenreType Type { get; set; }
    }
}
