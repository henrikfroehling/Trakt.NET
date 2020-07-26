namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncLastActivities>
    {
        public override async Task<ITraktSyncLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.PROPERTY_NAME_ALL:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    moviesLastActivities.All = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            moviesLastActivities.Movies = await moviesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            moviesLastActivities.Shows = await showsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            moviesLastActivities.Seasons = await seasonsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            moviesLastActivities.Episodes = await episodesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENTS:
                            moviesLastActivities.Comments = await commentsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTS:
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
