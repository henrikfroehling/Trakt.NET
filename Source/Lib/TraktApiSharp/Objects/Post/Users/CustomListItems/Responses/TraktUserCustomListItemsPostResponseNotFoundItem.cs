namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "ids")]
        public T Ids { get; set; }
    }
}
