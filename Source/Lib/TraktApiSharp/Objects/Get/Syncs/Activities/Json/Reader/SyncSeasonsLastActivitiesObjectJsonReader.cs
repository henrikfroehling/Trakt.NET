namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncSeasonsLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncSeasonsLastActivities>
    {
        public override async Task<ITraktSyncSeasonsLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncSeasonsLastActivities));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncSeasonsLastActivities seasonsLastActivities = new TraktSyncSeasonsLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    seasonsLastActivities.RatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_WATCHLISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    seasonsLastActivities.WatchlistedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    seasonsLastActivities.CommentedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_HIDDEN_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    seasonsLastActivities.HiddenAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return seasonsLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncSeasonsLastActivities));
        }
    }
}
