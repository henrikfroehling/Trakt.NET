namespace TraktApiSharp.Objects.Post.Checkins.Json.Writer
{
    using Basic.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class ACheckinPostObjectJsonWriter<TCheckinObjectType> : AObjectJsonWriter<TCheckinObjectType> where TCheckinObjectType : ITraktCheckinPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TCheckinObjectType obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Sharing != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_PROPERTY_NAME_SHARING, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Sharing, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Message))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_PROPERTY_NAME_MESSAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Message, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.AppVersion))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_PROPERTY_NAME_APP_VERSION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AppVersion, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.AppDate))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_PROPERTY_NAME_APP_DATE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AppDate, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.FoursquareVenueId))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_PROPERTY_NAME_VENUE_ID, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FoursquareVenueId, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.FoursquareVenueName))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CHECKIN_POST_PROPERTY_NAME_VENUE_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FoursquareVenueName, cancellationToken).ConfigureAwait(false);
            }

            await WriteCheckinObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected abstract Task WriteCheckinObjectAsync(JsonTextWriter jsonWriter, TCheckinObjectType obj, CancellationToken cancellationToken = default);
    }
}
