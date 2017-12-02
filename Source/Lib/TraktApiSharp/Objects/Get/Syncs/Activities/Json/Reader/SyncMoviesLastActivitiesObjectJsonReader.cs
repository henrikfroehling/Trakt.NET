namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncMoviesLastActivitiesObjectJsonReader : IObjectJsonReader<ITraktSyncMoviesLastActivities>
    {
        public Task<ITraktSyncMoviesLastActivities> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncMoviesLastActivities));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncMoviesLastActivities> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncMoviesLastActivities));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncMoviesLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncMoviesLastActivities));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncMoviesLastActivities moviesLastActivities = new TraktSyncMoviesLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.RatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_WATCHLISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.WatchlistedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVIITES_PROPERTY_NAME_COMMENTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.CommentedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_PAUSED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.PausedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_HIDDEN_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.HiddenAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return moviesLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncMoviesLastActivities));
        }
    }
}
