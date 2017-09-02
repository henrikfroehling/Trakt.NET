namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktSyncLastActivitiesObjectJsonReader : IObjectJsonReader<ITraktSyncLastActivities>
    {
        private const string PROPERTY_NAME_ALL = "all";
        private const string PROPERTY_NAME_MOVIES = "movies";
        private const string PROPERTY_NAME_SHOWS = "shows";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_EPISODES = "episodes";
        private const string PROPERTY_NAME_COMMENTS = "comments";
        private const string PROPERTY_NAME_LISTS = "lists";

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
                var moviesLastActivitiesReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();
                var showsLastActivitiesReader = new TraktSyncShowsLastActivitiesObjectJsonReader();
                var seasonsLastActivitiesReader = new TraktSyncSeasonsLastActivitiesObjectJsonReader();
                var episodesLastActivitiesReader = new TraktSyncEpisodesLastActivitiesObjectJsonReader();
                var commentsLastActivitiesReader = new SyncCommentsLastActivitiesObjectJsonReader();
                var listsLastActivitiesReader = new TraktSyncListsLastActivitiesObjectJsonReader();

                ITraktSyncLastActivities moviesLastActivities = new TraktSyncLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ALL:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.All = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_MOVIES:
                            moviesLastActivities.Movies = await moviesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOWS:
                            moviesLastActivities.Shows = await showsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASONS:
                            moviesLastActivities.Seasons = await seasonsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODES:
                            moviesLastActivities.Episodes = await episodesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_COMMENTS:
                            moviesLastActivities.Comments = await commentsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_LISTS:
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
