namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    /// <summary>An user personal list items post episode, containing the required episode number.</summary>
    public interface ITraktUserPersonalListItemsPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        int Number { get; set; }
    }
}
