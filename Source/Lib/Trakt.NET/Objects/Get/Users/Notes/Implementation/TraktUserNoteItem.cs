namespace TraktNet.Objects.Get.Users.Notes
{
    using Enums;
    using Episodes;
    using Movies;
    using People;
    using Seasons;
    using Shows;

    /// <summary>A Trakt user note item containing the note including the media object to which the note is attached.</summary>
    public class TraktUserNoteItem : ITraktUserNoteItem
    {
        /// <summary>
        /// Gets or sets information to which this note item is attached.
        /// If it is attached to an history item, this property contains the history item id.
        /// See also <seealso cref="ITraktUserNoteAttachedTo" />.
        /// </summary>
        public ITraktUserNoteAttachedTo AttachedTo { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this note item contains.
        /// See also <seealso cref="TraktListItemType" />.
        /// </summary>
        public TraktListItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktListItemType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" /> or
        /// <see cref="TraktListItemType.Season" />.
        /// <para>See also <seealso cref="ITraktShow" />.</para>
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="ITraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPerson Person { get; set; }

        /// <summary>
        /// Gets or sets the note content of this item.
        /// See also <seealso cref="ITraktUserNote" />.
        /// </summary>
        public ITraktUserNote Note { get; set; }
    }
}
