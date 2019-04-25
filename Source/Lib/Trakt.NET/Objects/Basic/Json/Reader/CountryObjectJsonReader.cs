namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CountryObjectJsonReader : AObjectJsonReader<ITraktCountry>
    {
        public override async Task<ITraktCountry> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCountry)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktCountry traktCountry = new TraktCountry();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    string propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.COUNTRY_PROPERTY_NAME_NAME:
                            traktCountry.Name = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.COUNTRY_PROPERTY_NAME_CODE:
                            traktCountry.Code = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktCountry;
            }

            return await Task.FromResult(default(ITraktCountry)).ConfigureAwait(false);
        }
    }
}
