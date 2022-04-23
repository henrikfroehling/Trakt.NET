namespace TraktNet.Objects.Get.Syncs.Activities.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCommentsLastActivitiesObjectJsonReader : AObjectJsonReader<ITraktSyncCommentsLastActivities>
    {
        public override async Task<ITraktSyncCommentsLastActivities> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCommentsLastActivities commentsLastActivities = new TraktSyncCommentsLastActivities();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_LIKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    commentsLastActivities.LikedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_BLOCKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    commentsLastActivities.BlockedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return commentsLastActivities;
            }

            return await Task.FromResult(default(ITraktSyncCommentsLastActivities));
        }
    }
}
