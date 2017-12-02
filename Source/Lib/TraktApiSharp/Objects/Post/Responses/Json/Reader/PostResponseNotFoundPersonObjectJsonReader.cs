namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Get.People.Json.Reader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundPersonObjectJsonReader : IObjectJsonReader<ITraktPostResponseNotFoundPerson>
    {
        public Task<ITraktPostResponseNotFoundPerson> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPostResponseNotFoundPerson));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPostResponseNotFoundPerson> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPostResponseNotFoundPerson));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPostResponseNotFoundPerson> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPostResponseNotFoundPerson));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var personIdsReader = new PersonIdsObjectJsonReader();
                ITraktPostResponseNotFoundPerson postResponseNotFoundPerson = new TraktPostResponseNotFoundPerson();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.POST_RESPONSE_NOT_FOUND_PERSON_PROPERTY_NAME_IDS:
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
