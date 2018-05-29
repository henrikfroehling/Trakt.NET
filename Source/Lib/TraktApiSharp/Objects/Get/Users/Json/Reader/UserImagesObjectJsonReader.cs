namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Basic.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserImagesObjectJsonReader : AObjectJsonReader<ITraktUserImages>
    {
        public override async Task<ITraktUserImages> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserImages));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var imageReader = new ImageObjectJsonReader();
                ITraktUserImages traktUserImage = new TraktUserImages();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_IMAGES_PROPERTY_NAME_AVATAR:
                            traktUserImage.Avatar = await imageReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserImage;
            }

            return await Task.FromResult(default(ITraktUserImages));
        }
    }
}
