namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    /// <summary>An user custom list items post episode, containing the required episode number.</summary>
    public class TraktUserCustomListItemsPostShowEpisode : ITraktUserCustomListItemsPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}
