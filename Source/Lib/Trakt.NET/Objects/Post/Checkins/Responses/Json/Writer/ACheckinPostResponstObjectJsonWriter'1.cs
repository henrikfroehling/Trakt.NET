namespace TraktNet.Objects.Post.Checkins.Responses.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class ACheckinPostResponstObjectJsonWriter<TCheckinResponseObjectType> : AObjectJsonWriter<TCheckinResponseObjectType> where TCheckinResponseObjectType : ITraktCheckinPostResponse
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TCheckinResponseObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (obj.WatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_WATCHED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.WatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Sharing != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_SHARING, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Sharing, cancellationToken).ConfigureAwait(false);
            }

            await WriteCheckinResponseObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected abstract Task WriteCheckinResponseObjectAsync(JsonTextWriter jsonWriter, TCheckinResponseObjectType obj, CancellationToken cancellationToken = default);
    }
}
