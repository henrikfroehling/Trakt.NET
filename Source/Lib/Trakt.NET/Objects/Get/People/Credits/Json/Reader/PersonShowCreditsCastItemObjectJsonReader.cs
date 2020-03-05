namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCastItemObjectJsonReader : AObjectJsonReader<ITraktPersonShowCreditsCastItem>
    {
        public override async Task<ITraktPersonShowCreditsCastItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonShowCreditsCastItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();

                ITraktPersonShowCreditsCastItem movieCreditsCastItem = new TraktPersonShowCreditsCastItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTER:
                            movieCreditsCastItem.Character = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTERS:
                            movieCreditsCastItem.Characters = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_SHOW:
                            movieCreditsCastItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCreditsCastItem;
            }

            return await Task.FromResult(default(ITraktPersonShowCreditsCastItem));
        }
    }
}
