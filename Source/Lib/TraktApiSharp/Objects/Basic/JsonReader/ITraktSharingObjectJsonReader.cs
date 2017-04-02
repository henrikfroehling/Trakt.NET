namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktSharingObjectJsonReader : ITraktObjectJsonReader<ITraktSharing>
    {
        private const string PROPERTY_NAME_FACEBOOK = "facebook";
        private const string PROPERTY_NAME_TWITTER = "twitter";
        private const string PROPERTY_NAME_GOOGLE = "google";
        private const string PROPERTY_NAME_TUMBLR = "tumblr";
        private const string PROPERTY_NAME_MEDIUM = "medium";
        private const string PROPERTY_NAME_SLACK = "slack";

        public Task<ITraktSharing> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSharing> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return null;

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSharing traktSharing = new TraktSharing();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_FACEBOOK:
                            traktSharing.Facebook = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_TWITTER:
                            traktSharing.Twitter = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_GOOGLE:
                            traktSharing.Google = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_TUMBLR:
                            traktSharing.Tumblr = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_MEDIUM:
                            traktSharing.Medium = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_SLACK:
                            traktSharing.Slack = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSharing;
            }

            return null;
        }
    }
}
