namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsRemovePostResponse
    {
        [JsonProperty(PropertyName = "deleted")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseGroup Deleted { get; set; }

        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseNotFound NotFound { get; set; }
    }
}
