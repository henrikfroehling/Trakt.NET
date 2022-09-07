namespace TraktNet.Objects.Post.Comments.Json.Writer
{
    using Get.Lists.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListCommentPostObjectJsonWriter : ACommentPostObjectJsonWriter<ITraktListCommentPost>
    {
        protected override async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, ITraktListCommentPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.List != null)
            {
                var listObjectJsonWriter = new ListObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIST, cancellationToken).ConfigureAwait(false);
                await listObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
