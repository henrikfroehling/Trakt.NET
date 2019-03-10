namespace TraktNet.Objects.Get.Movies.Json.Reader
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
                var traktMovies = new List<ITraktMovie>();
                ITraktMovie traktMovie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovie != null)
                {
                    traktMovies.Add(traktMovie);
                    traktMovie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovie>));
        }
    }
}
