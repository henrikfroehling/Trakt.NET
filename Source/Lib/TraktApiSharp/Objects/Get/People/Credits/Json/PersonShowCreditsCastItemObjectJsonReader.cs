namespace TraktApiSharp.Objects.Get.People.Credits.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCastItemObjectJsonReader : IObjectJsonReader<ITraktPersonShowCreditsCastItem>
    {
        private const string PROPERTY_NAME_CHARACTER = "character";
        private const string PROPERTY_NAME_SHOW = "show";

        public Task<ITraktPersonShowCreditsCastItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPersonShowCreditsCastItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPersonShowCreditsCastItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPersonShowCreditsCastItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPersonShowCreditsCastItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
                        case PROPERTY_NAME_CHARACTER:
                            movieCreditsCastItem.Character = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
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
