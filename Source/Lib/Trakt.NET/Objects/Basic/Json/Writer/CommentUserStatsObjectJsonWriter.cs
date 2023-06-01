namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentUserStatsObjectJsonWriter : AObjectJsonWriter<ITraktCommentUserStats>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCommentUserStats obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.PlayCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PLAY_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.PlayCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CompletedCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMPLETED_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CompletedCount, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
