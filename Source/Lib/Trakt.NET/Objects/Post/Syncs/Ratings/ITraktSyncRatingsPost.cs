namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt ratings post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's ratings.
    /// </summary>
    public interface ITraktSyncRatingsPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncRatingsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostShow" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncRatingsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostSeason" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncRatingsPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncRatingsPostEpisode> Episodes { get; set; }
    }
}
