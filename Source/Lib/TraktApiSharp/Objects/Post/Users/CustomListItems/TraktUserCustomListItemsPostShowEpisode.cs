namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsPostShowEpisode
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
