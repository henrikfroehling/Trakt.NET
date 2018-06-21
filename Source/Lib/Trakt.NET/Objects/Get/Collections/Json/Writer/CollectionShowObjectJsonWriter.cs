namespace TraktNet.Objects.Get.Collections.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowObjectJsonWriter : AObjectJsonWriter<ITraktCollectionShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCollectionShow obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.LastCollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_PROPERTY_NAME_LAST_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LastCollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectionSeasons != null)
            {
                var collectionShowSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_SHOW_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await collectionShowSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.CollectionSeasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
