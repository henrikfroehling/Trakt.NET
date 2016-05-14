namespace TraktApiSharp.Objects.Post.Users.ListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserListItemsPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "ids")]
        public T Ids { get; set; }
    }
}
