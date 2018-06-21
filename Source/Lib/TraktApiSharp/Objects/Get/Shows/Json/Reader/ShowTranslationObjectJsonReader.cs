namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowTranslationObjectJsonReader : AObjectJsonReader<ITraktShowTranslation>
    {
        public override async Task<ITraktShowTranslation> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowTranslation));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktShowTranslation traktShowTranslation = new TraktShowTranslation();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHOW_TRANSLATION_PROPERTY_NAME_TITLE:
                            traktShowTranslation.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_TRANSLATION_PROPERTY_NAME_OVERVIEW:
                            traktShowTranslation.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE:
                            traktShowTranslation.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowTranslation;
            }

            return await Task.FromResult(default(ITraktShowTranslation));
        }
    }
}
