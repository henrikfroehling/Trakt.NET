namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingObjectJsonReader : IObjectJsonReader<ITraktSharing>
    {
        public Task<ITraktSharing> ReadObjectAsync(string json, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSharing));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSharing> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSharing));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSharing> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSharing));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSharing traktSharing = new TraktSharing();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHARING_PROPERTY_NAME_FACEBOOK:
                            traktSharing.Facebook = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.SHARING_PROPERTY_NAME_TWITTER:
                            traktSharing.Twitter = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.SHARING_PROPERTY_NAME_GOOGLE:
                            traktSharing.Google = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.SHARING_PROPERTY_NAME_TUMBLR:
                            traktSharing.Tumblr = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.SHARING_PROPERTY_NAME_MEDIUM:
                            traktSharing.Medium = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.SHARING_PROPERTY_NAME_SLACK:
                            traktSharing.Slack = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSharing;
            }

            return await Task.FromResult(default(ITraktSharing));
        }
    }
}
