namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostFavoritedShowObjectJsonReader : AObjectJsonReader<ITraktMostFavoritedShow>
    {
        public override async Task<ITraktMostFavoritedShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktMostFavoritedShow traktMostFavoritedShow = new TraktMostFavoritedShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_USER_COUNT:
                            traktMostFavoritedShow.UserCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            var showObjectReader = new ShowObjectJsonReader();
                            traktMostFavoritedShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMostFavoritedShow;
            }

            return await Task.FromResult(default(ITraktMostFavoritedShow));
        }
    }
}
