namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses
{
    /// <summary>
    /// Represents the response for a recommendations remove post. See also <see cref="ITraktSyncRecommendationsRemovePostResponse" />.
    /// <para>Contains the number of deleted movies and shows and not found movies and shows.</para>
    /// </summary>
    public class TraktSyncRecommendationsRemovePostResponse : ITraktSyncRecommendationsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncRecommendationsPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies and shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncRecommendationsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
