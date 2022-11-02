namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses
{
    using Objects.Post.Responses;

    /// <summary>
    /// Represents the response for a recommendations remove post. See also <see cref="ITraktSyncRecommendationsRemovePostResponse" />.
    /// <para>Contains the number of deleted movies and shows and not found movies and shows.</para>
    /// </summary>
    public interface ITraktSyncRecommendationsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncRecommendationsPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies and shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncRecommendationsPostResponseNotFoundGroup NotFound { get; set; }

        /// <summary>
        /// Information about the updated list.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPostResponseListData List { get; set; }
    }
}
