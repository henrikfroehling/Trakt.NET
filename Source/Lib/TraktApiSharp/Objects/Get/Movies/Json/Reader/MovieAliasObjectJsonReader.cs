namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieAliasObjectJsonReader : AObjectJsonReader<ITraktMovieAlias>
    {
        public override async Task<ITraktMovieAlias> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMovieAlias));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktMovieAlias traktMovieAlias = new TraktMovieAlias();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.MOVIE_ALIAS_PROPERTY_NAME_TITLE:
                            traktMovieAlias.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.MOVIE_ALIAS_PROPERTY_NAME_COUNTRY:
                            traktMovieAlias.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMovieAlias;
            }

            return await Task.FromResult(default(ITraktMovieAlias));
        }
    }
}
