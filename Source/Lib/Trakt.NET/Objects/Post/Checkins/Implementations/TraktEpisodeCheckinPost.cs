namespace TraktNet.Objects.Post.Checkins
{
    using Get.Episodes;
    using Get.Shows;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A checkin post for a Trakt episode.</summary>
    public class TraktEpisodeCheckinPost : TraktCheckinPost, ITraktEpisodeCheckinPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the checkin post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the checkin post.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktEpisodeCheckinPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktEpisodeCheckinPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            if (Episode == null)
                throw new ArgumentNullException(nameof(Episode), "episode must not be null");

            if (Episode.Number < 1)
                throw new ArgumentOutOfRangeException(nameof(Episode.Number), "episode number must be at least 1");

            if (Episode.SeasonNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(Episode.SeasonNumber), "episode season number must be at least 1");

            if (Episode.Ids == null)
                throw new ArgumentNullException(nameof(Episode.Ids), "episode.Ids must not be null");

            if (!Episode.Ids.HasAnyId)
                throw new ArgumentException("episode.Ids have no valid id", nameof(Episode.Ids));

            if (Show != null && string.IsNullOrEmpty(Show.Title))
                throw new ArgumentException("show title not valid", nameof(Show.Title));
        }
    }
}
