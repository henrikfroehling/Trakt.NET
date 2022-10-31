namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Checkins;

    public interface ITraktEpisodeCheckinPostBuilder : ITraktCheckinPostBuilder<ITraktEpisodeCheckinPostBuilder, ITraktEpisodeCheckinPost>
    {
        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktEpisodeCheckinPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="episode"/>s ids are not valid.</exception>
        ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="show"/> and a season and episode number to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasonNumber">The season number which will be added.</param>
        /// <param name="episodeNumber">The episode number which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktEpisodeCheckinPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="show"/>s ids are not valid.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="seasonNumber"/> is not valid.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="episodeNumber"/> is not valid.</exception>
        ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktShow show, int seasonNumber, int episodeNumber);
    }
}
