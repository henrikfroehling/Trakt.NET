namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncShowsLastActivitiesObjectJsonReader : IObjectJsonReader<ITraktSyncShowsLastActivities>
    {
        private const string PROPERTY_NAME_RATED_AT = "rated_at";
        private const string PROPERTY_NAME_WATCHLISTED_AT = "watchlisted_at";
        private const string PROPERTY_NAME_COMMENTED_AT = "commented_at";
        private const string PROPERTY_NAME_HIDDEN_AT = "hidden_at";

        public Task<ITraktSyncShowsLastActivities> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncShowsLastActivities));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncShowsLastActivities> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncShowsLastActivities));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncShowsLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncShowsLastActivities));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncShowsLastActivities showsLastActivities = new TraktSyncShowsLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    showsLastActivities.RatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_WATCHLISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    showsLastActivities.WatchlistedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_COMMENTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    showsLastActivities.CommentedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_HIDDEN_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    showsLastActivities.HiddenAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return showsLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncShowsLastActivities));
        }
    }
}
