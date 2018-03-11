namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieAliasArrayJsonReader : AArrayJsonReader<ITraktMovieAlias>
    {
        public override async Task<IEnumerable<ITraktMovieAlias>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieAlias>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieAliasReader = new MovieAliasObjectJsonReader();
                //var traktMovieAliasReadingTasks = new List<Task<ITraktMovieAlias>>();
                var traktMovieAliass = new List<ITraktMovieAlias>();

                //traktMovieAliasReadingTasks.Add(movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovieAlias traktMovieAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieAlias != null)
                {
                    traktMovieAliass.Add(traktMovieAlias);
                    //traktMovieAliasReadingTasks.Add(movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovieAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovieAliass = await Task.WhenAll(traktMovieAliasReadingTasks);
                //return (IEnumerable<ITraktMovieAlias>)readMovieAliass.GetEnumerator();
                return traktMovieAliass;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieAlias>));
        }
    }
}
