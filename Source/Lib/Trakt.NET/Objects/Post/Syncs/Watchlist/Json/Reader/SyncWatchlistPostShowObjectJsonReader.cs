namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostShowObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostShow>
    {
        public override async Task<ITraktSyncWatchlistPostShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showIdsObjectJsonReader = new ShowIdsObjectJsonReader();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktSyncWatchlistPostShowSeason>();
                ITraktSyncWatchlistPostShow syncWatchlistPostShow = new TraktSyncWatchlistPostShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TITLE:
                            syncWatchlistPostShow.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_YEAR:
                            syncWatchlistPostShow.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncWatchlistPostShow.Ids = await showIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            syncWatchlistPostShow.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPostShow;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistPostShow));
        }
    }
}
