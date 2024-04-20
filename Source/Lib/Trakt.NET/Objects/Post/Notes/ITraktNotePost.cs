namespace TraktNet.Objects.Post.Notes
{
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Requests.Interfaces;

    /// <summary>A note post.</summary>
    public interface ITraktNotePost : IRequestBody
    {
        /// <summary>
        /// Gets or sets the info to which collection, history item or rating this note is attached.
        /// See also <seealso cref="ITraktNoteAttachedTo" />.
        /// </summary>
        ITraktNoteAttachedTo AttachedTo { get; set; }

        /// <summary>Gets or sets whether the note contains any spoilers.</summary>
        bool? Spoiler { get; set; }

        /// <summary>Gets or sets the privacy setting for the note.</summary>
        TraktListPrivacy Privacy { get; set; }

        /// <summary>Gets or sets the note's content.</summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Trakt movie.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the Trakt season.
        /// See also <seealso cref="ITraktSeason" />.
        /// </summary>
        ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the Trakt episode.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt person.
        /// See also <seealso cref="ITraktPerson" />.
        /// </summary>
        ITraktPerson Person { get; set; }
    }
}
