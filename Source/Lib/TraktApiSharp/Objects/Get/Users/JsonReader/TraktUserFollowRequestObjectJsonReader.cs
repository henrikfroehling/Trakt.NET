namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserFollowRequestObjectJsonReader : ITraktObjectJsonReader<ITraktUserFollowRequest>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_REQUESTED_AT = "requested_at";
        private const string PROPERTY_NAME_USER = "user";

        public Task<ITraktUserFollowRequest> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserFollowRequest));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserFollowRequest> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserFollowRequest));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserFollowRequest> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserFollowRequest));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userReader = new TraktUserObjectJsonReader();
                ITraktUserFollowRequest traktUserFollowRequest = new TraktUserFollowRequest();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserFollowRequest.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_REQUESTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserFollowRequest.RequestedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_USER:
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
