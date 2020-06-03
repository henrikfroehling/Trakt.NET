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
                var traktMostAnticipatedMovies = new List<ITraktMostAnticipatedMovie>();
                ITraktMostAnticipatedMovie traktMostAnticipatedMovie = await mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostAnticipatedMovie != null)
                {
                    traktMostAnticipatedMovies.Add(traktMostAnticipatedMovie);
                    traktMostAnticipatedMovie = await mostAnticipatedMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMostAnticipatedMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedMovie>));
        }
    }
}
