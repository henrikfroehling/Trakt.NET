namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieArrayJsonReader : AArrayJsonReader<ITraktMovie>
    {
        public override async Task<IEnumerable<ITraktMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieReader = new MovieObjectJsonReader();
                //var traktMovieReadingTasks = new List<Task<ITraktMovie>>();
                var traktMovies = new List<ITraktMovie>();

                //traktMovieReadingTasks.Add(movieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovie traktMovie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovie != null)
                {
                    traktMovies.Add(traktMovie);
                    //traktMovieReadingTasks.Add(movieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovies = await Task.WhenAll(traktMovieReadingTasks);
                //return (IEnumerable<ITraktMovie>)readMovies.GetEnumerator();
                return traktMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovie>));
        }
    }
}
