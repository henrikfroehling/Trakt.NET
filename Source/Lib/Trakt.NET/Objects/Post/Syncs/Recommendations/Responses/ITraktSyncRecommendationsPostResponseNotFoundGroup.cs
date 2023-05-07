namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses
{
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of recommended movies and shows, which were not found.</summary>
    public interface ITraktSyncRecommendationsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktSyncRecommendationsPostMovie" />, containing the ids of recommended movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktSyncRecommendationsPostMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktSyncRecommendationsPostShow" />, containing the ids of recommended shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktSyncRecommendationsPostShow> Shows { get; set; }
    }
}
