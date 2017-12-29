namespace TraktApiSharp.Objects.Get.Movies.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieReleaseArrayJsonReader : AArrayJsonReader<ITraktMovieRelease>
    {
        public override async Task<IEnumerable<ITraktMovieRelease>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieRelease>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieReleaseReader = new MovieReleaseObjectJsonReader();
                //var traktMovieReleaseReadingTasks = new List<Task<ITraktMovieRelease>>();
                var traktMovieReleases = new List<ITraktMovieRelease>();

                //traktMovieReleaseReadingTasks.Add(movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMovieRelease traktMovieRelease = await movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMovieRelease != null)
                {
                    traktMovieReleases.Add(traktMovieRelease);
                    //traktMovieReleaseReadingTasks.Add(movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMovieRelease = await movieReleaseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMovieReleases = await Task.WhenAll(traktMovieReleaseReadingTasks);
                //return (IEnumerable<ITraktMovieRelease>)readMovieReleases.GetEnumerator();
                return traktMovieReleases;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieRelease>));
        }
    }
}
