namespace TraktNet.Objects.Post.Checkins.Responses.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CheckinPostErrorResponseObjectJsonWriter : AObjectJsonWriter<ITraktCheckinPostErrorResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCheckinPostErrorResponse obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.ExpiresAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_ERROR_RESPONSE_PROPERTY_NAME_EXPIRES_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ExpiresAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
