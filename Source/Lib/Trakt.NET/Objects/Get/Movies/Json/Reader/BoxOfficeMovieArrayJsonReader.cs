namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BoxOfficeMovieArrayJsonReader : ArrayJsonReader<ITraktBoxOfficeMovie>
    {
        public override async Task<IEnumerable<ITraktBoxOfficeMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var boxOfficeMovieReader = new BoxOfficeMovieObjectJsonReader();
                var traktBoxOfficeMovies = new List<ITraktBoxOfficeMovie>();
                ITraktBoxOfficeMovie traktBoxOfficeMovie = await boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktBoxOfficeMovie != null)
                {
                    traktBoxOfficeMovies.Add(traktBoxOfficeMovie);
                    traktBoxOfficeMovie = await boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktBoxOfficeMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));
        }
    }
}
