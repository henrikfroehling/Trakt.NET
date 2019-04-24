﻿namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    /// <summary>Contains information about a Trakt user's hidden item, including the corresponding movie, show or season.</summary>
    public interface ITraktUserHiddenItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show or season was hidden.</summary>
        DateTime? HiddenAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this hidden item contains.
        /// See also <seealso cref="TraktHiddenItemType" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktHiddenItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable<
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSeason Season { get; set; }
    }
}
