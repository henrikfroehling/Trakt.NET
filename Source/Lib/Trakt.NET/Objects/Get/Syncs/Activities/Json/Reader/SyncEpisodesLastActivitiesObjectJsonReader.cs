namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncEpisodesLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncEpisodesLastActivities>
    {
        public override async Task<ITraktSyncEpisodesLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.RatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_WATCHLISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.WatchlistedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_COMMENTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodesLastActivities.CommentedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_PAUSED_AT:
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
