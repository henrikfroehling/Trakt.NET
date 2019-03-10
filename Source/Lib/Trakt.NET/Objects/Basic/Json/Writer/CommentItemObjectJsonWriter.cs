namespace TraktNet.Objects.Basic.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Get.Movies.Json.Writer;
    using Get.Seasons.Json.Writer;
    using Get.Shows.Json.Writer;
    using Get.Users.Lists.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentItemObjectJsonWriter : AObjectJsonWriter<ITraktCommentItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCommentItem obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_ITEM_PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_ITEM_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_ITEM_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Season != null)
            {
                var seasonObjectJsonWriter = new SeasonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_ITEM_PROPERTY_NAME_SEASON, cancellationToken).ConfigureAwait(false);
                await seasonObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Season, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_ITEM_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var listObjectJsonWriter = new ListObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_ITEM_PROPERTY_NAME_LIST, cancellationToken).ConfigureAwait(false);
                await listObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
