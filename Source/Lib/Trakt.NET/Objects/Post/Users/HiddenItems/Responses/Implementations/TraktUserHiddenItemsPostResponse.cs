namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    /// <summary>
    /// Represents the response for an user hidden items post. See also <see cref="ITraktUserHiddenItemsPost" />.
    /// <para>Contains the number of added and not found movies, shows and seasons.</para>
    /// </summary>
    public class TraktUserHiddenItemsPostResponse : ITraktUserHiddenItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows and seasons.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserHiddenItemsPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows and seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUserHiddenItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
