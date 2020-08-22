namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserIdsObjectJsonReader : AObjectJsonReader<ITraktUserIds>
    {
        public override async Task<ITraktUserIds> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserIds traktUserIds = new TraktUserIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_SLUG:
                            traktUserIds.Slug = jsonReader.ReadAsString();
                            break;
                        case JsonProperties.PROPERTY_NAME_UUID:
                            traktUserIds.UUID = jsonReader.ReadAsString();
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserIds;
            }

            return await Task.FromResult(default(ITraktUserIds));
        }
    }
}
