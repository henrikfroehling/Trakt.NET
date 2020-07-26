namespace TraktNet.Objects.Post.Scrobbles.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieScrobblePostArrayJsonReader : ArrayJsonReader<ITraktMovieScrobblePost>
    {
        public override async Task<IEnumerable<ITraktMovieScrobblePost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieScrobblePost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieScrobblePostReader = new MovieScrobblePostObjectJsonReader();
                var movieScrobblePosts = new List<ITraktMovieScrobblePost>();
                ITraktMovieScrobblePost movieScrobblePost = await movieScrobblePostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (movieScrobblePost != null)
                {
                    movieScrobblePosts.Add(movieScrobblePost);
                    movieScrobblePost = await movieScrobblePostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return movieScrobblePosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieScrobblePost>));
        }
    }
}
