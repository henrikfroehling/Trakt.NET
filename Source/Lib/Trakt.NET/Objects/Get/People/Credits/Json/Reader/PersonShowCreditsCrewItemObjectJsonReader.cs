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

                ITraktPersonShowCreditsCrewItem showCreditsCrewItem = new TraktPersonShowCreditsCrewItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_JOB:
                            showCreditsCrewItem.Job = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_JOBS:
                            showCreditsCrewItem.Jobs = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_EPISODE_COUNT:
                            {
                                var value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    showCreditsCrewItem.EpisodeCount = value.Second;

                                break;
                            }
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_SHOW:
                            showCreditsCrewItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return showCreditsCrewItem;
            }

            return await Task.FromResult(default(ITraktPersonShowCreditsCrewItem));
        }
    }
}
