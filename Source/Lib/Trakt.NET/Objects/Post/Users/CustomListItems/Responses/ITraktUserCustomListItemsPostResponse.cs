namespace TraktNet.Objects.Post.Users.CustomListItems.Responses
{
    /// <summary>
    /// Represents the response for an user custom list items post. See also <see cref="ITraktUserCustomListItemsPost" />.
    /// <para>Contains the number of added, existing and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public interface ITraktUserCustomListItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserCustomListItemsPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserCustomListItemsPostResponseGroup Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUserCustomListItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
