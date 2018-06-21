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
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserIds));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserIds traktUserIds = new TraktUserIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_IDS_PROPERTY_NAME_SLUG:
                            traktUserIds.Slug = jsonReader.ReadAsString();
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
