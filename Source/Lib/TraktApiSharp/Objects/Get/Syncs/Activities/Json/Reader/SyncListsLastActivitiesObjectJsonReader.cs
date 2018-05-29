namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncListsLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncListsLastActivities>
    {
        public override async Task<ITraktSyncListsLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncListsLastActivities));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncListsLastActivities listsLastActivities = new TraktSyncListsLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_LISTS_LAST_ACTIVITIES_PROPERTY_NAME_LIKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    listsLastActivities.LikedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_LISTS_LAST_ACTIVITIES_PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    listsLastActivities.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_LISTS_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    listsLastActivities.CommentedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return listsLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncListsLastActivities));
        }
    }
}
