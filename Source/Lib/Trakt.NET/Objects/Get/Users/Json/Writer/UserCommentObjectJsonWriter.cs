namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Basic.Json.Writer;
    using Episodes.Json.Writer;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Writer;
    using Shows.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Lists.Json.Writer;

    internal class UserCommentObjectJsonWriter : AObjectJsonWriter<ITraktUserComment>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserComment obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comment != null)
            {
                var commentObjectJsonWriter = new CommentObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_COMMENT, cancellationToken).ConfigureAwait(false);
                await commentObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Comment, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Season != null)
            {
                var seasonObjectJsonWriter = new SeasonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_SEASON, cancellationToken).ConfigureAwait(false);
                await seasonObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Season, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var listObjectJsonWriter = new ListObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_COMMENT_PROPERTY_NAME_LIST, cancellationToken).ConfigureAwait(false);
                await listObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
