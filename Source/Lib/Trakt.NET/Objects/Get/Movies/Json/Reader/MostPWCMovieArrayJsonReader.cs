namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCMovieArrayJsonReader : ArrayJsonReader<ITraktMostPWCMovie>
    {
        public override async Task<IEnumerable<ITraktMostPWCMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostPWCMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostPWCMovieReader = new MostPWCMovieObjectJsonReader();
                var traktMostPWCMovies = new List<ITraktMostPWCMovie>();
                ITraktMostPWCMovie traktMostPWCMovie = await mostPWCMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostPWCMovie != null)
                {
                    traktMostPWCMovies.Add(traktMostPWCMovie);
                    traktMostPWCMovie = await mostPWCMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMostPWCMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostPWCMovie>));
        }
    }
}
