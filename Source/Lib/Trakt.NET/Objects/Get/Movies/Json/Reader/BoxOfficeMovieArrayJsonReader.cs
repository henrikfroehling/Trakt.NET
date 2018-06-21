namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BoxOfficeMovieArrayJsonReader : AArrayJsonReader<ITraktBoxOfficeMovie>
    {
        public override async Task<IEnumerable<ITraktBoxOfficeMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var boxOfficeMovieReader = new BoxOfficeMovieObjectJsonReader();
                //var traktBoxOfficeMovieReadingTasks = new List<Task<ITraktBoxOfficeMovie>>();
                var traktBoxOfficeMovies = new List<ITraktBoxOfficeMovie>();

                //traktBoxOfficeMovieReadingTasks.Add(boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktBoxOfficeMovie traktBoxOfficeMovie = await boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktBoxOfficeMovie != null)
                {
                    traktBoxOfficeMovies.Add(traktBoxOfficeMovie);
                    //traktBoxOfficeMovieReadingTasks.Add(boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktBoxOfficeMovie = await boxOfficeMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readBoxOfficeMovies = await Task.WhenAll(traktBoxOfficeMovieReadingTasks);
                //return (IEnumerable<ITraktBoxOfficeMovie>)readBoxOfficeMovies.GetEnumerator();
                return traktBoxOfficeMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktBoxOfficeMovie>));
        }
    }
}
