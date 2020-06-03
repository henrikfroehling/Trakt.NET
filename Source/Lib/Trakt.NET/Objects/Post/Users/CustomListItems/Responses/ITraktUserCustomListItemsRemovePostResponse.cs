namespace TraktNet.Objects.Post.Users.CustomListItems.Responses
{
    /// <summary>
    /// Represents the response for an user custom list items remove post. See also <see cref="ITraktUserCustomListItemsPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public interface ITraktUserCustomListItemsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserCustomListItemsPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserCustomListItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
