namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewItemObjectJsonReader : AObjectJsonReader<ITraktPersonShowCreditsCrewItem>
    {
        public override async Task<ITraktPersonShowCreditsCrewItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonShowCreditsCrewItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();

                ITraktPersonShowCreditsCrewItem movieCreditsCrewItem = new TraktPersonShowCreditsCrewItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_JOB:
                            movieCreditsCrewItem.Job = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_JOBS:
                            movieCreditsCrewItem.Jobs = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_SHOW:
                            movieCreditsCrewItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCreditsCrewItem;
            }

            return await Task.FromResult(default(ITraktPersonShowCreditsCrewItem));
        }
    }
}
