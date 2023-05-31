namespace TraktNet.Objects.Basic.Json.Writer
{
    using Extensions;
    using Get.Users.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ACommentObjectJsonWriter<TCommentObjectType> : AObjectJsonWriter<TCommentObjectType> where TCommentObjectType : ITraktComment
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TCommentObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteCommentObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, TCommentObjectType obj, CancellationToken cancellationToken = default)
        {
            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (obj.ParentId.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PARENT_ID, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ParentId, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CREATED_AT, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.CreatedAt.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Comment))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMMENT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comment, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SPOILER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Spoiler, cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_REVIEW, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Review, cancellationToken).ConfigureAwait(false);

            if (obj.Replies.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_REPLIES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Replies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Likes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIKES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Likes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.UserStats != null)
            {
                var userStatsObjectJsonWriter = new CommentUserStatsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER_STATS, cancellationToken).ConfigureAwait(false);
                await userStatsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.UserStats, cancellationToken).ConfigureAwait(false);
            }

            if (obj.User != null)
            {
                var userObjectJsonWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.User, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
