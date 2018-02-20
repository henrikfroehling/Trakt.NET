namespace TraktApiSharp.Objects.Post.Checkins.Json.Writer
{
    using Basic.Json.Writer;
    using Get.Episodes.Json.Writer;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCheckinPostObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeCheckinPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeCheckinPost obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Sharing != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_SHARING, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Sharing, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Message))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_MESSAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Message, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.AppVersion))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_APP_VERSION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AppVersion, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.AppDate))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_APP_DATE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AppDate, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.FoursquareVenueId))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_VENUE_ID, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FoursquareVenueId, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.FoursquareVenueName))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_VENUE_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FoursquareVenueName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_CHECKIN_POST_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
