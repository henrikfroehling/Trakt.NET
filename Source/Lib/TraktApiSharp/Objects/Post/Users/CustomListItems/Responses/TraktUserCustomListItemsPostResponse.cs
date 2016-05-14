namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        public TraktUserCustomListItemsPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "existing")]
        public TraktUserCustomListItemsPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktUserCustomListItemsPostResponseNotFound NotFound { get; set; }
    }
}
