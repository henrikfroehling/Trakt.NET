namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses
{
    using Objects.Post.Responses;

    /// <summary>
    /// Represents the response for a recommendations post. See also <see cref="ITraktSyncRecommendationsPost" />.
    /// <para>Contains the number of added, existing and not found movies and shows.</para>
    /// </summary>
    public interface ITraktSyncRecommendationsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncRecommendationsPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncRecommendationsPostResponseGroup Existing { get; set; }

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
