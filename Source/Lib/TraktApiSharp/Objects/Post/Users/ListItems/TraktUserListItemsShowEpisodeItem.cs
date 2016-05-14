namespace TraktApiSharp.Objects.Post.Users.ListItems
{
    using Newtonsoft.Json;

    public class TraktUserListItemsShowEpisodeItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
