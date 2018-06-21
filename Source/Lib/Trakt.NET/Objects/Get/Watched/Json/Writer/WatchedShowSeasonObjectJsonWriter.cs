namespace TraktNet.Objects.Get.Watched.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowSeasonObjectJsonWriter : AObjectJsonWriter<ITraktWatchedShowSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktWatchedShowSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.WATCHED_SHOW_SEASON_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var watchedShowEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktWatchedShowEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.WATCHED_SHOW_SEASON_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await watchedShowEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
