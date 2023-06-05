namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    /// <summary>Contains information about a Trakt user's hidden item, including the corresponding movie, show or season.</summary>
    public class TraktUserHiddenItem : ITraktUserHiddenItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show or season was hidden.</summary>
        public DateTime? HiddenAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this hidden item contains.
        /// See also <seealso cref="TraktHiddenItemType" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktHiddenItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the user, if <see cref="Type" /> is <see cref="TraktHiddenItemType.User" />.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUser User { get; set; }
    }
}
