namespace TraktApiSharp.Objects.Get.People.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonObjectJsonReader : IObjectJsonReader<ITraktPerson>
    {
        public Task<ITraktPerson> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPerson));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPerson> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPerson));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPerson> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPerson));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new PersonIdsObjectJsonReader();
                ITraktPerson traktPerson = new TraktPerson();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_PROPERTY_NAME_NAME:
                            traktPerson.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PERSON_PROPERTY_NAME_IDS:
                            traktPerson.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_PROPERTY_NAME_BIOGRAPHY:
                            traktPerson.Biography = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PERSON_PROPERTY_NAME_BIRTHDAY:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPerson.Birthday = value.Second;

                                break;
                            }
                        case JsonProperties.PERSON_PROPERTY_NAME_DEATH:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPerson.Death = value.Second;

                                break;
                            }
                        case JsonProperties.PERSON_PROPERTY_NAME_BIRTHPLACE:
                            traktPerson.Birthplace = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PERSON_PROPERTY_NAME_HOMEPAGE:
                            traktPerson.Homepage = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktPerson;
            }

            return await Task.FromResult(default(ITraktPerson));
        }
    }
}
