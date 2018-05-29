namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncMoviesLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncMoviesLastActivities>
    {
        public override async Task<ITraktSyncMoviesLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT:
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
