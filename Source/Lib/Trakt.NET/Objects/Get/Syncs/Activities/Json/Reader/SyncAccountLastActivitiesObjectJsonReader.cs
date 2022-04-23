namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncAccountLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncAccountLastActivities>
    {
        public override async Task<ITraktSyncAccountLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncAccountLastActivities accountLastActivities = new TraktSyncAccountLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_SETTINGS_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    accountLastActivities.SettingsAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_FOLLOWED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    accountLastActivities.FollowedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_FOLLOWING_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    accountLastActivities.FollowingAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_PENDING_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    accountLastActivities.PendingAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return accountLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncAccountLastActivities));
        }
    }
}
