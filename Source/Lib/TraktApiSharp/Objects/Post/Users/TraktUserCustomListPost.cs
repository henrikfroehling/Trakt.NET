namespace TraktApiSharp.Objects.Post.Users
{
    using Attributes;
    using Enums;
    using Newtonsoft.Json;

    public class TraktUserCustomListPost
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        [Nullable]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "privacy")]
        [JsonConverter(typeof(TraktAccessScopeConverter))]
        public TraktAccessScope? Privacy { get; set; }

        [JsonProperty(PropertyName = "display_numbers")]
        public bool? DisplayNumbers { get; set; }

        [JsonProperty(PropertyName = "allow_comments")]
        public bool? AllowComments { get; set; }
    }
}
