namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieTranslationArrayJsonReader : ArrayJsonReader<ITraktMovieTranslation>
    {
        public override async Task<IEnumerable<ITraktMovieTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieTranslationReader = new MovieTranslationObjectJsonReader();
                var traktMovieTranslations = new List<ITraktMovieTranslation>();
                ITraktMovieTranslation traktMovieTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieTranslation != null)
                {
                    traktMovieTranslations.Add(traktMovieTranslation);
                    traktMovieTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMovieTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));
        }
    }
}
