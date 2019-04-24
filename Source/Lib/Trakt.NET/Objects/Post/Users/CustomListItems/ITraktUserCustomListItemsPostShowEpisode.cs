namespace TraktNet.Objects.Post.Users.CustomListItems
{
    /// <summary>An user custom list items post episode, containing the required episode number.</summary>
    public interface ITraktUserCustomListItemsPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        int Number { get; set; }
    }
}
