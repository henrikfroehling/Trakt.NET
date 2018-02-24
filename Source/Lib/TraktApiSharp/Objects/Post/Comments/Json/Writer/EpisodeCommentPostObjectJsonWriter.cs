namespace TraktApiSharp.Objects.Post.Comments.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCommentPostObjectJsonWriter : ACommentPostObjectJsonWriter<ITraktEpisodeCommentPost>
    {
        protected override async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeCommentPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_COMMENT_POST_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
