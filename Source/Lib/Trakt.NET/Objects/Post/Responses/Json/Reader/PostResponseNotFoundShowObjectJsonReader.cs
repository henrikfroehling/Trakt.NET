namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundShowObjectJsonReader : AObjectJsonReader<ITraktPostResponseNotFoundShow>
    {
        public override async Task<ITraktPostResponseNotFoundShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showIdsReader = new ShowIdsObjectJsonReader();
                ITraktPostResponseNotFoundShow postResponseNotFoundShow = new TraktPostResponseNotFoundShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            postResponseNotFoundShow.Ids = await showIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return postResponseNotFoundShow;
            }

            return await Task.FromResult(default(ITraktPostResponseNotFoundShow));
        }
    }
}
