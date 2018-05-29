namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows;
    using Objects.Json;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A show comment post.</summary>
    public class TraktShowCommentPost : TraktCommentPost, ITraktShowCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        public ITraktShow Show { get; set; }

        public override HttpContent ToHttpContent()
        {
            throw new System.NotImplementedException();
        }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktShowCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktShowCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            // TODO
        }
    }
}
