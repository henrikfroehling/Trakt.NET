namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using TraktNet.Objects.Json;

    internal class SyncHistoryRemovePostSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostSeason>
    {
        public override async Task<ITraktSyncHistoryRemovePostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsReader = new SeasonIdsObjectJsonReader();
                ITraktSyncHistoryRemovePostSeason syncHistoryRemovePostSeason = new TraktSyncHistoryRemovePostSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncHistoryRemovePostSeason.Ids = await seasonIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostSeason;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostSeason));
        }
    }
}
