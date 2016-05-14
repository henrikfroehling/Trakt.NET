namespace TraktApiSharp.Objects.Post.Users.ListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserListItemsRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktUserListItemsPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktUserListItemsPostResponseNotFound NotFound { get; set; }
    }
}
