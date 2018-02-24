namespace TraktApiSharp.Objects.Post.Comments.Json.Writer
{
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCommentPostObjectJsonWriter : ACommentPostObjectJsonWriter<ITraktShowCommentPost>
    {
        protected override async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, ITraktShowCommentPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_COMMENT_POST_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
