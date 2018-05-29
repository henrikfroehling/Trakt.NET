namespace TraktApiSharp.Objects.Get.Ratings
{
    using Enums;
    using Episodes;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    /// <summary>A Trakt rating item, containing a movie, show, season and / or episode and information about it.</summary>
    public class TraktRatingsItem : ITraktRatingsItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show, season and / or episode was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the rating of the movie, show, season and / or episode.</summary>
        public int? Rating { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this rating item contains.
        /// See also <seealso cref="TraktRatingsItemType" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktRatingsItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Episode" /> or
        /// <see cref="TraktRatingsItemType.Season" />.
        /// <para>See also <seealso cref="ITraktShow" />.</para>
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisode Episode { get; set; }
    }
}
