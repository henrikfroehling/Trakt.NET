namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncWatchlistPostSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncWatchlistPostSeason>
    {
        public override async Task<ITraktSyncWatchlistPostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsObjectJsonReader = new SeasonIdsObjectJsonReader();
                ITraktSyncWatchlistPostSeason syncWatchlistPostSeason = new TraktSyncWatchlistPostSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncWatchlistPostSeason.Ids = await seasonIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            syncWatchlistPostSeason.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPostSeason;
            }

            return await Task.FromResult(default(ITraktSyncWatchlistPostSeason));
        }
    }
}
