namespace TraktApiSharp.Objects.Get.Seasons.Json.Writer
{
    using Episodes;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCollectionProgressObjectJsonWriter : AObjectJsonWriter<ITraktSeasonCollectionProgress>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSeasonCollectionProgress obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Aired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_AIRED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Aired, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var episodeCollectionProgressArrayJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await episodeCollectionProgressArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
