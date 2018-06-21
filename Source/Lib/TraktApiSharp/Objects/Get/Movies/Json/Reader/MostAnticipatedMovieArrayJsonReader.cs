namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedMovieArrayJsonReader : AArrayJsonReader<ITraktMostAnticipatedMovie>
    {
        public override async Task<IEnumerable<ITraktMostAnticipatedMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostAnticipatedMovieReader = new MostAnticipatedMovieObjectJsonReader();
                //var traktMostAnticipatedMovieReadingTasks = new List<Task<ITraktMostAnticipatedMovie>>();
                var traktMostAnticipatedMovies = new List<ITraktMostAnticipatedMovie>();

                //traktMostAnticipatedMovieReadingTasks.Add(mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostAnticipatedMovie traktMostAnticipatedMovie = await mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostAnticipatedMovie != null)
                {
                    traktMostAnticipatedMovies.Add(traktMostAnticipatedMovie);
                    //traktMostAnticipatedMovieReadingTasks.Add(mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostAnticipatedMovie = await mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostAnticipatedMovies = await Task.WhenAll(traktMostAnticipatedMovieReadingTasks);
                //return (IEnumerable<ITraktMostAnticipatedMovie>)readMostAnticipatedMovies.GetEnumerator();
                return traktMostAnticipatedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));
        }
    }
}
