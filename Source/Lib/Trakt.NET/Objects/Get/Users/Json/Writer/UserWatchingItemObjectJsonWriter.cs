namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Episodes.Json.Writer;
    using Extensions;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserWatchingItemObjectJsonWriter : AObjectJsonWriter<ITraktUserWatchingItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserWatchingItem obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.StartedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_STARTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.StartedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.ExpiresAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_EXPIRES_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ExpiresAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Action != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_ACTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Action.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_WATCHING_ITEM_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
