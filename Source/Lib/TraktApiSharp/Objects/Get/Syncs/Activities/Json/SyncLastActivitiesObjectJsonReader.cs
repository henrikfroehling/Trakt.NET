namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncLastActivitiesObjectJsonReader : IObjectJsonReader<ITraktSyncLastActivities>
    {
        public Task<ITraktSyncLastActivities> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSyncLastActivities));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSyncLastActivities> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSyncLastActivities));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSyncLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncLastActivities));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var moviesLastActivitiesReader = new SyncMoviesLastActivitiesObjectJsonReader();
                var showsLastActivitiesReader = new SyncShowsLastActivitiesObjectJsonReader();
                var seasonsLastActivitiesReader = new SyncSeasonsLastActivitiesObjectJsonReader();
                var episodesLastActivitiesReader = new SyncEpisodesLastActivitiesObjectJsonReader();
                var commentsLastActivitiesReader = new SyncCommentsLastActivitiesObjectJsonReader();
                var listsLastActivitiesReader = new SyncListsLastActivitiesObjectJsonReader();

                ITraktSyncLastActivities moviesLastActivities = new TraktSyncLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_ALL:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.All = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_MOVIES:
                            moviesLastActivities.Movies = await moviesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_SHOWS:
                            moviesLastActivities.Shows = await showsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_SEASONS:
                            moviesLastActivities.Seasons = await seasonsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_EPISODES:
                            moviesLastActivities.Episodes = await episodesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTS:
                            moviesLastActivities.Comments = await commentsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_LAST_ACTIVITIES_PROPERTY_NAME_LISTS:
                            moviesLastActivities.Lists = await listsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return moviesLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncLastActivities));
        }
    }
}
