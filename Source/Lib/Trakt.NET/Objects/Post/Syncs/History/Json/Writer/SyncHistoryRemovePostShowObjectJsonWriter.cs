namespace TraktNet.Objects.Post.Syncs.History.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Shows.Json.Writer;
    using TraktNet.Objects.Json;

    internal class SyncHistoryRemovePostShowObjectJsonWriter : AObjectJsonWriter<ITraktSyncHistoryRemovePostShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncHistoryRemovePostShow obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

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
                var syncHistoryRemovePostShowSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncHistoryRemovePostShowSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncHistoryRemovePostShowSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
