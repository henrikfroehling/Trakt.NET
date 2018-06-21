namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieTranslationArrayJsonReader : AArrayJsonReader<ITraktMovieTranslation>
    {
        public override async Task<IEnumerable<ITraktMovieTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieTranslationReader = new MovieTranslationObjectJsonReader();
                //var traktMovieTranslationReadingTasks = new List<Task<ITraktMovieTranslation>>();
                var traktMovieTranslations = new List<ITraktMovieTranslation>();

                //traktMovieTranslationReadingTasks.Add(movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovieTranslation traktMovieTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieTranslation != null)
                {
                    traktMovieTranslations.Add(traktMovieTranslation);
                    //traktMovieTranslationReadingTasks.Add(movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovieTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovieTranslations = await Task.WhenAll(traktMovieTranslationReadingTasks);
                //return (IEnumerable<ITraktMovieTranslation>)readMovieTranslations.GetEnumerator();
                return traktMovieTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieTranslation>));
        }
    }
}
