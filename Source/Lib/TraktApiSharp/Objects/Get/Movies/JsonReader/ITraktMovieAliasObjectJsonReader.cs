namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ITraktMovieAliasObjectJsonReader : ITraktObjectJsonReader<ITraktMovieAlias>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_COUNTRY = "country";

        public Task<ITraktMovieAlias> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMovieAlias));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMovieAlias> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMovieAlias));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMovieAlias> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
                        case PROPERTY_NAME_TITLE:
                            traktMovieAlias.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_COUNTRY:
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
