namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Users.Lists;
    using Objects.Json;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A list comment post.</summary>
    public class TraktListCommentPost : TraktCommentPost, ITraktListCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="ITraktList" />.
        /// </summary>
        public ITraktList List { get; set; }

        public override HttpContent ToHttpContent()
        {
            throw new System.NotImplementedException();
        }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktListCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktListCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            // TODO
        }
    }
}
