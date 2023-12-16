namespace TraktNet.Objects.Get.Users.Notes.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserNoteAttachedToObjectJsonReader : AObjectJsonReader<ITraktUserNoteAttachedTo>
    {
        public override async Task<ITraktUserNoteAttachedTo> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserNoteAttachedTo userNoteAttachedTo = new TraktUserNoteAttachedTo();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            userNoteAttachedTo.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktNotesObjectType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    userNoteAttachedTo.Id = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userNoteAttachedTo;
            }

            return await Task.FromResult(default(ITraktUserNoteAttachedTo));
        }
    }
}
