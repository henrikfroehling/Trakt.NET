namespace TraktApiSharp.Objects.Post.Users.Responses.JsonReader
{
    using Get.Users.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowUserPostResponseObjectJsonReader : IObjectJsonReader<ITraktUserFollowUserPostResponse>
    {
        private const string PROPERTY_NAME_APPROVED_AT = "approved_at";
        private const string PROPERTY_NAME_USER = "user";

        public Task<ITraktUserFollowUserPostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserFollowUserPostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserFollowUserPostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserFollowUserPostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserFollowUserPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserFollowUserPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userObjectReader = new UserObjectJsonReader();
                ITraktUserFollowUserPostResponse userFollowUserPostResponse = new TraktUserFollowUserPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_APPROVED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    userFollowUserPostResponse.ApprovedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_USER:
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
