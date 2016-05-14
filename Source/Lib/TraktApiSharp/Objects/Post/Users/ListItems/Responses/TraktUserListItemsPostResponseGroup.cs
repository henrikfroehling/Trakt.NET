namespace TraktApiSharp.Objects.Post.Users.ListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserListItemsPostResponseGroup
    {
        [JsonProperty(PropertyName = "movies")]
        public int? Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public int? Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public int? Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public int? Episodes { get; set; }

        [JsonProperty(PropertyName = "people")]
        public int? People { get; set; }
    }
}
