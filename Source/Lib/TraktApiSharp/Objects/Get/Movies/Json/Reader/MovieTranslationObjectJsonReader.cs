namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieTranslationObjectJsonReader : AObjectJsonReader<ITraktMovieTranslation>
    {
        public override async Task<ITraktMovieTranslation> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMovieTranslation));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.MOVIE_TRANSLATION_PROPERTY_NAME_TITLE:
                            traktMovieTranslation.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.MOVIE_TRANSLATION_PROPERTY_NAME_OVERVIEW:
                            traktMovieTranslation.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.MOVIE_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE:
                            traktMovieTranslation.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.MOVIE_TRANSLATION_PROPERTY_NAME_TAGLINE:
                            traktMovieTranslation.Tagline = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMovieTranslation;
            }

            return await Task.FromResult(default(ITraktMovieTranslation));
        }
    }
}
