namespace TraktApiSharp.Objects.Get.Collections.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowSeasonObjectJsonWriter : AObjectJsonWriter<ITraktCollectionShowSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCollectionShowSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_SEASON_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var collectionShowEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktCollectionShowEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_SEASON_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await collectionShowEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
