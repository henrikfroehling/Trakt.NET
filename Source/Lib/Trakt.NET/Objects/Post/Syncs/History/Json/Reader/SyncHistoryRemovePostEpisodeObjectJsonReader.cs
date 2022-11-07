namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using TraktNet.Objects.Json;

    internal class SyncHistoryRemovePostEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostEpisode>
    {
        public override async Task<ITraktSyncHistoryRemovePostEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsReader = new EpisodeIdsObjectJsonReader();
                ITraktSyncHistoryRemovePostEpisode syncHistoryRemovePostEpisode = new TraktSyncHistoryRemovePostEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncHistoryRemovePostEpisode.Ids = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostEpisode;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostEpisode));
        }
    }
}
