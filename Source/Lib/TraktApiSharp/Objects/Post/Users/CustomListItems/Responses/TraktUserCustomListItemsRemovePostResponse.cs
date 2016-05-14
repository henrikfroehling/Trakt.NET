namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        public TraktUserCustomListItemsPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        public TraktUserCustomListItemsPostResponseNotFound NotFound { get; set; }
    }
}
