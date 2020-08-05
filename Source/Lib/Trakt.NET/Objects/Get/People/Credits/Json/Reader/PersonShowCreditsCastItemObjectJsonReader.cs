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

                ITraktPersonShowCreditsCastItem showCreditsCastItem = new TraktPersonShowCreditsCastItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_CHARACTERS:
                            showCreditsCastItem.Characters = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE_COUNT:
                            {
                                var value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    showCreditsCastItem.EpisodeCount = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SERIES_REGULAR:
                            showCreditsCastItem.SeriesRegular = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            showCreditsCastItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return showCreditsCastItem;
            }

            return await Task.FromResult(default(ITraktPersonShowCreditsCastItem));
        }
    }
}
