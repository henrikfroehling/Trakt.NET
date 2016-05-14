namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsShowEpisodeItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
