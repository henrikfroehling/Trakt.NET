namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Newtonsoft.Json;

    /// <summary>An user custom list items post episode, containing the required episode number.</summary>
    public class TraktUserCustomListItemsPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
