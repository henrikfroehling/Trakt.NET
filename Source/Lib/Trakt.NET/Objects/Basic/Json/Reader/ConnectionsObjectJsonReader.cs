namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ConnectionsObjectJsonReader : AObjectJsonReader<ITraktConnections>
    {
        public override async Task<ITraktConnections> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktConnections connections = new TraktConnections();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TWITTER:
                            connections.Twitter = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_GOOGLE:
                            connections.Google = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_TUMBLR:
                            connections.Tumblr = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MEDIUM:
                            connections.Medium = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SLACK:
                            connections.Slack = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_FACEBOOK:
                            connections.Facebook = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_APPLE:
                            connections.Apple = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MASTODON:
                            connections.Mastodon = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MICROSOFT:
                            connections.Microsoft = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DROPBOX:
                            connections.Dropbox = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return connections;
            }

            return await Task.FromResult(default(ITraktConnections));
        }
    }
}
