namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFavoritesLimitsObjectJsonReader : AObjectJsonReader<ITraktUserFavoritesLimits>
    {
        public override async Task<ITraktUserFavoritesLimits> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserFavoritesLimits userFavoritesLimits = new TraktUserFavoritesLimits();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ITEM_COUNT:
                            userFavoritesLimits.ItemCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userFavoritesLimits;
            }

            return await Task.FromResult(default(ITraktUserFavoritesLimits));
        }
    }
}
