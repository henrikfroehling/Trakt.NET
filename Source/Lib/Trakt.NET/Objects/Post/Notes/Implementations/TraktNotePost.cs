namespace TraktNet.Objects.Post.Notes
{
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Json;

    /// <summary>A note post.</summary>
    public class TraktNotePost : ITraktNotePost
    {
        /// <summary>
        /// Gets or sets the info to which collection, history item or rating this note is attached.
        /// See also <seealso cref="ITraktNoteAttachedTo" />.
        /// </summary>
        public ITraktNoteAttachedTo AttachedTo { get; set; }

        /// <summary>Gets or sets whether the note contains any spoilers.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>Gets or sets the privacy setting for the note.</summary>
        public TraktListPrivacy Privacy { get; set; }

        /// <summary>Gets or sets the note's content.</summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Trakt movie.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the Trakt season.
        /// See also <seealso cref="ITraktSeason" />.
        /// </summary>
        public ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the Trakt episode.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt person.
        /// See also <seealso cref="ITraktPerson" />.
        /// </summary>
        public ITraktPerson Person { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktNotePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktNotePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            if (Notes == null)
            {
                throw new TraktPostValidationException(nameof(Notes), "notes must not be null");
            }

            if (AttachedTo == null && Movie == null && Show == null && Season == null && Episode == null && Person == null)
            {
                throw new TraktPostValidationException("note post must contain a media object");
            }
        }
    }
}
