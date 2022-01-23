namespace TraktNet.Objects.Post.Syncs.Recommendations
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>A Trakt recommendations post, containing all movies and shows, which should be recommendated by an user.</summary>
    public interface ITraktSyncRecommendationsPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncRecommendationsPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncRecommendationsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncRecommendationsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRecommendationsPostShow" />s.
        /// <para>Each <see cref="ITraktSyncRecommendationsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncRecommendationsPostShow> Shows { get; set; }
    }
}
