namespace TraktApiSharp.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsObjectJsonReader : AObjectJsonReader<ITraktPersonShowCredits>
    {
        public override async Task<ITraktPersonShowCredits> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonShowCredits));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showCreditsCastReader = new PersonShowCreditsCastItemArrayJsonReader();
                var showCreditsCrewReader = new PersonShowCreditsCrewObjectJsonReader();

                ITraktPersonShowCredits showCredits = new TraktPersonShowCredits();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_SHOW_CREDITS_PROPERTY_NAME_CAST:
                            showCredits.Cast = await showCreditsCastReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_PROPERTY_NAME_CREW:
                            showCredits.Crew = await showCreditsCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return showCredits;
            }

            return await Task.FromResult(default(ITraktPersonShowCredits));
        }
    }
}
