namespace TraktNet.Objects.Post.Syncs.History.Json.Writer
{
    using Extensions;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryPostShowObjectJsonWriter : AObjectJsonWriter<ITraktSyncHistoryPostShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryPostShow obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.WatchedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WATCHED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.WatchedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
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
                var syncHistoryPostShowSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncHistoryPostShowSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncHistoryPostShowSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
