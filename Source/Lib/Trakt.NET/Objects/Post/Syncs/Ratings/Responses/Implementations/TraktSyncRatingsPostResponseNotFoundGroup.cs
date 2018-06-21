namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of rated movies, shows, seasons and episodes, which were not found.</summary>
    public class TraktSyncRatingsPostResponseNotFoundGroup : ITraktSyncRatingsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktSyncRatingsPostResponseNotFoundMovie" />, containing the ids of rated movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktSyncRatingsPostResponseNotFoundShow" />, containing the ids of rated shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktSyncRatingsPostResponseNotFoundSeason" />, containing the ids of rated seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktSyncRatingsPostResponseNotFoundEpisode" />, containing the ids of rated episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode> Episodes { get; set; }
    }
}
