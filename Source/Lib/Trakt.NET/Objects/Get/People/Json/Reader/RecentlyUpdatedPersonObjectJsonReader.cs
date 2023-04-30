namespace TraktNet.Objects.Get.People.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedPersonObjectJsonReader : AObjectJsonReader<ITraktRecentlyUpdatedPerson>
    {
        public override async Task<ITraktRecentlyUpdatedPerson> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new PersonObjectJsonReader();
                ITraktRecentlyUpdatedPerson traktRecentlyUpdatedPerson = new TraktRecentlyUpdatedPerson();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecentlyUpdatedPerson.RecentlyUpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_PERSON:
                            traktRecentlyUpdatedPerson.Person = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRecentlyUpdatedPerson;
            }

            return await Task.FromResult(default(ITraktRecentlyUpdatedPerson));
        }
    }
}
