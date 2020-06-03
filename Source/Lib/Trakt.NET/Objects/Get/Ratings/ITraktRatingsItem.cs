namespace TraktNet.Objects.Get.Ratings
{
    using Enums;
    using Episodes;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    /// <summary>A Trakt rating item, containing a movie, show, season and / or episode and information about it.</summary>
    public interface ITraktRatingsItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show, season and / or episode was rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the rating of the movie, show, season and / or episode.</summary>
        int? Rating { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this rating item contains.
        /// See also <seealso cref="TraktRatingsItemType" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktRatingsItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Episode" /> or
        /// <see cref="TraktRatingsItemType.Season" />.
        /// <para>See also <seealso cref="ITraktShow" />.</para>
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode Episode { get; set; }
    }
}
