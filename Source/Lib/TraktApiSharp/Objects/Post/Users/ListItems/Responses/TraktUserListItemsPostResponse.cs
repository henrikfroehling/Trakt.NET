namespace TraktApiSharp.Objects.Post.Users.ListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserListItemsPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktUserListItemsPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "existing")]
        public TraktUserListItemsPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktUserListItemsPostResponseNotFound NotFound { get; set; }
    }
}
