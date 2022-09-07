namespace TraktNet.Objects.Get.Lists
{
    using Enums;
    using Episodes;
    using Movies;
    using People;
    using Seasons;
    using Shows;
    using System;

    /// <summary>Represents a Trakt user list item.</summary>
    public interface ITraktListItem
    {
        /// <summary>Gets or sets the id of the list item.<para>Nullable</para></summary>
        uint? Id { get; set; }

        /// <summary>Gets or sets the ranking number of the list item.<para>Nullable</para></summary>
        string Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the list item was added to a list.</summary>
        DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the list item type. See also <seealso cref="TraktListItemType" />.<para>Nullable</para></summary>
        TraktListItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the list item movie, if <see cref="Type" /> is <see cref="TraktListItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the list item show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the list item season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the list item episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the list item person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="ITraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPerson Person { get; set; }
    }
}
