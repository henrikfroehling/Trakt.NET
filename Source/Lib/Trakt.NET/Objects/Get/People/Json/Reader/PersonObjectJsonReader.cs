namespace TraktNet.Objects.Get.People.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonObjectJsonReader : AObjectJsonReader<ITraktPerson>
    {
        public override async Task<ITraktPerson> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new PersonIdsObjectJsonReader();
                var socialIdsObjectReader = new PersonSocialIdsObjectJsonReader();
                ITraktPerson traktPerson = new TraktPerson();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NAME:
                            traktPerson.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            traktPerson.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_BIOGRAPHY:
                            traktPerson.Biography = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_BIRTHDAY:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPerson.Birthday = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_DEATH:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPerson.Death = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_BIRTHPLACE:
                            traktPerson.Birthplace = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_HOMEPAGE:
                            traktPerson.Homepage = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_GENDER:
                            traktPerson.Gender = await JsonReaderHelper.ReadEnumerationValueAsync<TraktGender>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_KNOWN_FOR_DEPARTMENT:
                            traktPerson.KnownForDepartment = await JsonReaderHelper.ReadEnumerationValueAsync<TraktKnownForDepartment>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SOCIAL_IDS:
                            traktPerson.SocialIds = await socialIdsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktPerson.UpdatedAt = value.Second;

                                break;
                            }
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
