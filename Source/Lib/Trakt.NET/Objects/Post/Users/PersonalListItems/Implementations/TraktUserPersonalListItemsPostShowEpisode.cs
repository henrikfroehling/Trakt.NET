namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    /// <summary>An user personal list items post episode, containing the required episode number.</summary>
    public class TraktUserPersonalListItemsPostShowEpisode : ITraktUserPersonalListItemsPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}
