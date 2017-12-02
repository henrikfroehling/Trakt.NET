namespace TraktApiSharp.Objects.Get.People.Credits.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsObjectJsonReader : IObjectJsonReader<ITraktPersonShowCredits>
    {
        public Task<ITraktPersonShowCredits> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPersonShowCredits));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPersonShowCredits> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPersonShowCredits));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPersonShowCredits> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
