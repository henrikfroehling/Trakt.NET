namespace TraktNet.Objects.Get.Notes.Json.Reader
{
    using Enums;
    using Get.Users.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NoteObjectJsonReader : AObjectJsonReader<ITraktNote>
    {
        public override async Task<ITraktNote> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userObjectReader = new UserObjectJsonReader();

                ITraktNote userNote = new TraktNote();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    userNote.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            userNote.Notes = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PRIVACY:
                            userNote.Privacy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktListPrivacy>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            userNote.Spoiler = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    userNote.CreatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    userNote.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_USER:
                            userNote.User = await userObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userNote;
            }

            return await Task.FromResult(default(ITraktNote));
        }
    }
}
