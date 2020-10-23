namespace TraktNet.Objects.Post.Syncs.Collection.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostShowObjectJsonWriter : AMetadataObjectJsonWriter<ITraktSyncCollectionPostShow>
    {
        protected override async Task WriteMetadataObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPostShow obj, CancellationToken cancellationToken = default)
        {
            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Year.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_YEAR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Year, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var showIdsObjectJsonWriter = new ShowIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await showIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncCollectionPostShowSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostShowSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostShowSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            await base.WriteMetadataObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
        }
    }
}
