namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses
{
    using Get.Movies;
    using Get.Shows;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of recommended movies and shows, which were not found.</summary>
    public interface ITraktSyncRecommendationsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktMovieIds" />, containing the ids of recommended movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktMovieIds> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktShowIds" />, containing the ids of recommended shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktShowIds> Shows { get; set; }
    }
}
