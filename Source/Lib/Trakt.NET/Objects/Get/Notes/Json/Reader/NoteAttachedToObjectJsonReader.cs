namespace TraktNet.Objects.Get.Notes.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NoteAttachedToObjectJsonReader : AObjectJsonReader<ITraktNoteAttachedTo>
    {
        public override async Task<ITraktNoteAttachedTo> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktNoteAttachedTo userNoteAttachedTo = new TraktNoteAttachedTo();

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

            return await Task.FromResult(default(ITraktNoteAttachedTo));
        }
    }
}
