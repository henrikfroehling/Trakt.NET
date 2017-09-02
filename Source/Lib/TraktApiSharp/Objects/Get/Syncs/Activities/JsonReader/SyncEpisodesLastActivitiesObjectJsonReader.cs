namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncEpisodesLastActivitiesObjectJsonReader : IObjectJsonReader<ITraktSyncEpisodesLastActivities>
    {
        private const string PROPERTY_NAME_WATCHED_AT = "watched_at";
        private const string PROPERTY_NAME_COLLECTED_AT = "collected_at";
        private const string PROPERTY_NAME_RATED_AT = "rated_at";
        private const string PROPERTY_NAME_WATCHLISTED_AT = "watchlisted_at";
        private const string PROPERTY_NAME_COMMENTED_AT = "commented_at";
        private const string PROPERTY_NAME_PAUSED_AT = "paused_at";

        public Task<ITraktSyncEpisodesLastActivities> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncEpisodesLastActivities));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncEpisodesLastActivities> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncEpisodesLastActivities));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncEpisodesLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncEpisodesLastActivities));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncEpisodesLastActivities episodesLastActivities = new TraktSyncEpisodesLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.WatchedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.CollectedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.RatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_WATCHLISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.WatchlistedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_COMMENTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.CommentedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_PAUSED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.PausedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return episodesLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncEpisodesLastActivities));
        }
    }
}
