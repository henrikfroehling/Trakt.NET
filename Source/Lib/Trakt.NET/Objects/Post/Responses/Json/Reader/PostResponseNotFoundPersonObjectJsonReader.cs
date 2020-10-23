namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Get.People.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundPersonObjectJsonReader : AObjectJsonReader<ITraktPostResponseNotFoundPerson>
    {
        public override async Task<ITraktPostResponseNotFoundPerson> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var personIdsReader = new PersonIdsObjectJsonReader();
                ITraktPostResponseNotFoundPerson postResponseNotFoundPerson = new TraktPostResponseNotFoundPerson();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            postResponseNotFoundPerson.Ids = await personIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return postResponseNotFoundPerson;
            }

            return await Task.FromResult(default(ITraktPostResponseNotFoundPerson));
        }
    }
}
