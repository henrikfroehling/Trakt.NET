namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowRequestObjectJsonReader : AObjectJsonReader<ITraktUserFollowRequest>
    {
        public override async Task<ITraktUserFollowRequest> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userReader = new UserObjectJsonReader();
                ITraktUserFollowRequest traktUserFollowRequest = new TraktUserFollowRequest();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserFollowRequest.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_REQUESTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserFollowRequest.RequestedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_USER:
                            traktUserFollowRequest.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserFollowRequest;
            }

            return await Task.FromResult(default(ITraktUserFollowRequest));
        }
    }
}
