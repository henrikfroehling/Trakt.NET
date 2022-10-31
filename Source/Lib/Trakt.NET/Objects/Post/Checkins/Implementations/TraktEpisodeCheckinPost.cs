namespace TraktNet.Objects.Post.Checkins
{
    using Exceptions;
    using Get.Episodes;
    using Get.Shows;
    using Objects.Json;
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
                throw new TraktPostValidationException(nameof(Episode), "episode must not be null");

            if (Show == null)
            {
                if (Episode.Ids == null)
                    throw new TraktPostValidationException($"{nameof(Episode)}.Ids", "episode ids must not be null");

                if (!Episode.Ids.HasAnyId)
                    throw new TraktPostValidationException($"{nameof(Episode)}.Ids", "episode ids have no valid id");
            }
            else
            {
                if (Show.Ids == null)
                    throw new TraktPostValidationException($"{nameof(Show)}.Ids", "show ids must not be null");

                if (!Show.Ids.HasAnyId)
                    throw new TraktPostValidationException($"{nameof(Show)}.Ids", "show ids have no valid id");

                if (Episode.SeasonNumber < 0)
                    throw new TraktPostValidationException($"{nameof(Episode)}.SeasonNumber", "episode season number must be valid, if episode ids not valid or empty");

                if (Episode.Number < 1)
                    throw new TraktPostValidationException($"{nameof(Episode)}.Number", "episode number must be valid, if episode ids not valid or empty");
            }
        }
    }
}
