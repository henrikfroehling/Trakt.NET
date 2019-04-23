namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class LanguageObjectJsonReader : AObjectJsonReader<ITraktLanguage>
    {
        public override async Task<ITraktLanguage> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktLanguage)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktLanguage traktLanguage = new TraktLanguage();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    string propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.LANGUAGE_PROPERTY_NAME_NAME:
                            traktLanguage.Name = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.LANGUAGE_PROPERTY_NAME_CODE:
                            traktLanguage.Code = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktLanguage;
            }

            return await Task.FromResult(default(ITraktLanguage)).ConfigureAwait(false);
        }
    }
}
