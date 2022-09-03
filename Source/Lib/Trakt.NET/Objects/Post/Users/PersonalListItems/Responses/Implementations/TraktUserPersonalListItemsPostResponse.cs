namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses
{
    /// <summary>
    /// Represents the response for an user personal list items post. See also <see cref="ITraktUserPersonalListItemsPost" />.
    /// <para>Contains the number of added, existing and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public class TraktUserPersonalListItemsPostResponse : ITraktUserPersonalListItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserPersonalListItemsPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserPersonalListItemsPostResponseGroup Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserPersonalListItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
