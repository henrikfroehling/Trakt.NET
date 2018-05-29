namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a ratings post. See also <see cref="ITraktSyncRatingsPost" />.
    /// <para>Contains the number of added and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncRatingsPostResponse : ITraktSyncRatingsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncRatingsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
