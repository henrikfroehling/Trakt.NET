namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsPostResponse
    {
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseGroup Added { get; set; }

        [JsonProperty(PropertyName = "existing")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseGroup Existing { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseNotFound NotFound { get; set; }
    }
}
