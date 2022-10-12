namespace TraktNet.Objects.Post.Syncs.Collection.Json.Writer
{
    using Extensions;
    using Get.Seasons.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostSeasonObjectJsonWriter : AMetadataObjectJsonWriter<ITraktSyncCollectionPostSeason>
    {
        protected override async Task WriteMetadataObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPostSeason obj, CancellationToken cancellationToken = default)
        {
            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var seasonIdsObjectJsonWriter = new SeasonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await seasonIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await base.WriteMetadataObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
        }
    }
}
