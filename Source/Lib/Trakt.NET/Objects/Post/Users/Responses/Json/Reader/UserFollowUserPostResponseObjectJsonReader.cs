namespace TraktNet.Objects.Post.Users.Responses.Json.Reader
{
    using Get.Users.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowUserPostResponseObjectJsonReader : AObjectJsonReader<ITraktUserFollowUserPostResponse>
    {
        public override async Task<ITraktUserFollowUserPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userObjectReader = new UserObjectJsonReader();
                ITraktUserFollowUserPostResponse userFollowUserPostResponse = new TraktUserFollowUserPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_APPROVED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    userFollowUserPostResponse.ApprovedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_USER:
                            userFollowUserPostResponse.User = await userObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userFollowUserPostResponse;
            }

            return await Task.FromResult(default(ITraktUserFollowUserPostResponse));
        }
    }
}
