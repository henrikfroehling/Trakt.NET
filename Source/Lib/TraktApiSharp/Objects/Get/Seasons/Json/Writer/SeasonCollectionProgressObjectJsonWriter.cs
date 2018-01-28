namespace TraktApiSharp.Objects.Get.Seasons.Json.Writer
{
    using Episodes.Json.Writer;
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

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken);
            }

            if (obj.Aired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_AIRED, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Aired, cancellationToken);
            }

            if (obj.Completed.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Completed, cancellationToken);
            }

            if (obj.Episodes != null)
            {
                var episodeCollectionProgressArrayJsonWriter = new EpisodeCollectionProgressArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_EPISODES, cancellationToken);
                await episodeCollectionProgressArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
