namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowAliasObjectJsonReader : AObjectJsonReader<ITraktShowAlias>
    {
        public override async Task<ITraktShowAlias> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowAlias));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktShowAlias traktShowAlias = new TraktShowAlias();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHOW_ALIAS_PROPERTY_NAME_TITLE:
                            traktShowAlias.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_ALIAS_PROPERTY_NAME_COUNTRY:
                            traktShowAlias.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowAlias;
            }

            return await Task.FromResult(default(ITraktShowAlias));
        }
    }
}
