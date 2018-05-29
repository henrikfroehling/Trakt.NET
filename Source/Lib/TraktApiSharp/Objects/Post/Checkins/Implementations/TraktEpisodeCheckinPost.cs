namespace TraktApiSharp.Objects.Post.Checkins
{
    using Get.Episodes;
    using Get.Shows;
    using Objects.Json;
    using System.Net.Http;
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

        public override HttpContent ToHttpContent()
        {
            throw new System.NotImplementedException();
        }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktEpisodeCheckinPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktEpisodeCheckinPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            // TODO
        }
    }
}
