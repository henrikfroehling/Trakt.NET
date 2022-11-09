namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;
    using TraktNet.Utils;

    internal class SyncHistoryRemovePostShowEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostShowEpisode>
    {
        public override async Task<ITraktSyncHistoryRemovePostShowEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncHistoryRemovePostShowEpisode syncHistoryRemovePostShowEpisode = new TraktSyncHistoryRemovePostShowEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryRemovePostShowEpisode.Number = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostShowEpisode;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostShowEpisode));
        }
    }
}
