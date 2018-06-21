namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingTextObjectJsonReader : AObjectJsonReader<ITraktSharingText>
    {
        public override async Task<ITraktSharingText> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSharingText));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSharingText traktSharingText = new TraktSharingText();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHARING_TEXT_PROPERTY_NAME_WATCHING:
                            traktSharingText.Watching = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHARING_TEXT_PROPERTY_NAME_WATCHED:
                            traktSharingText.Watched = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSharingText;
            }

            return await Task.FromResult(default(ITraktSharingText));
        }
    }
}
