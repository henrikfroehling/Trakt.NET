namespace TraktApiSharp.Objects.Post.Users
{
    using Enums;
    using Newtonsoft.Json;

    public class TraktUserListPost
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "privacy")]
        [JsonConverter(typeof(TraktAccessScopeConverter))]
        public TraktAccessScope Privacy { get; set; }

        [JsonProperty(PropertyName = "display_numbers")]
        public bool? DisplayNumbers { get; set; }

        [JsonProperty(PropertyName = "allow_comments")]
        public bool? AllowComments { get; set; }
    }
}
