namespace TraktApiSharp.Objects.Post.Checkins.Implementations
{
    using Get.Episodes;
    using Get.Shows;
    using System.Net.Http;

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

        public override string HttpContentAsString
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
