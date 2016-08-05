namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public T Ids { get; set; }
    }
}
