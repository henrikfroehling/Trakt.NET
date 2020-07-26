namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieAliasArrayJsonReader : ArrayJsonReader<ITraktMovieAlias>
    {
        public override async Task<IEnumerable<ITraktMovieAlias>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieAlias>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieAliasReader = new MovieAliasObjectJsonReader();
                var traktMovieAliass = new List<ITraktMovieAlias>();
                ITraktMovieAlias traktMovieAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieAlias != null)
                {
                    traktMovieAliass.Add(traktMovieAlias);
                    traktMovieAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMovieAliass;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieAlias>));
        }
    }
}
