namespace TraktNet.Objects.Get.Notes
{
    using Enums;
    using Episodes;
    using Movies;
    using People;
    using Seasons;
    using Shows;

    /// <summary>A Trakt user note item containing the note including the media object to which the note is attached.</summary>
    public interface ITraktNoteItem
    {
        /// <summary>
        /// Gets or sets information to which this note item is attached.
        /// If it is attached to an history item, this property contains the history item id.
        /// See also <seealso cref="ITraktNoteAttachedTo" />.
        /// </summary>
        ITraktNoteAttachedTo AttachedTo { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this note item contains.
        /// See also <seealso cref="TraktListItemType" />.
        /// </summary>
        TraktListItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktListItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" /> or
        /// <see cref="TraktListItemType.Season" />.
        /// <para>See also <seealso cref="ITraktShow" />.</para>
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="ITraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPerson Person { get; set; }

        /// <summary>
        /// Gets or sets the note content of this item.
        /// See also <seealso cref="ITraktNote" />.
        /// </summary>
        ITraktNote Note { get; set; }
    }
}
