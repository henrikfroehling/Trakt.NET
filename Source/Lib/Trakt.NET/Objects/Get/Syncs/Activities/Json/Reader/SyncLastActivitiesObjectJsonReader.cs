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
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var moviesLastActivitiesReader = new SyncMoviesLastActivitiesObjectJsonReader();
                var showsLastActivitiesReader = new SyncShowsLastActivitiesObjectJsonReader();
                var seasonsLastActivitiesReader = new SyncSeasonsLastActivitiesObjectJsonReader();
                var episodesLastActivitiesReader = new SyncEpisodesLastActivitiesObjectJsonReader();
                var commentsLastActivitiesReader = new SyncCommentsLastActivitiesObjectJsonReader();
                var listsLastActivitiesReader = new SyncListsLastActivitiesObjectJsonReader();
                var accountLastActivitiesReader = new SyncAccountLastActivitiesObjectJsonReader();
                var recommendationsLastActivitiesReader = new SyncRecommendationsLastActivitiesObjectJsonReader();
                var watchlistLastActivitiesReader = new SyncWatchlistLastActivitiesObjectJsonReader();
                var savedFiltersLastActivitiesReader = new SyncSavedFiltersLastActivitiesObjectJsonReader();
                var favoritesLastActivitiesReader = new SyncFavoritesLastActivitiesObjectJsonReader();
                var collaborationsLastActivitiesReader = new SyncCollaborationsLastActivitiesObjectJsonReader();
                var notesLastActivitiesReader = new SyncNotesLastActivitiesObjectJsonReader();

                ITraktSyncLastActivities lastActivities = new TraktSyncLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ALL:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    lastActivities.All = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            lastActivities.Movies = await moviesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            lastActivities.Episodes = await episodesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            lastActivities.Shows = await showsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            lastActivities.Seasons = await seasonsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENTS:
                            lastActivities.Comments = await commentsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTS:
                            lastActivities.Lists = await listsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_WATCHLIST:
                            lastActivities.Watchlist = await watchlistLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_FAVORITES:
                            lastActivities.Favorites = await favoritesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RECOMMENDATIONS:
                            lastActivities.Recommendations = await recommendationsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COLLABORATIONS:
                            lastActivities.Collaborations = await collaborationsLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_ACCOUNT:
                            lastActivities.Account = await accountLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SAVED_FILTERS:
                            lastActivities.SavedFilters = await savedFiltersLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            lastActivities.Notes = await notesLastActivitiesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return lastActivities;
            }

            return await Task.FromResult(default(ITraktSyncLastActivities));
        }
    }
}
