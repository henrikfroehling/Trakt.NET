namespace TraktNet.Objects.Post.Checkins.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCheckinPostArrayJsonReader : AArrayJsonReader<ITraktMovieCheckinPost>
    {
        public override async Task<IEnumerable<ITraktMovieCheckinPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieCheckinPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieCheckinPostReader = new MovieCheckinPostObjectJsonReader();
                var movieCheckinPosts = new List<ITraktMovieCheckinPost>();
                ITraktMovieCheckinPost movieCheckinPost = await movieCheckinPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (movieCheckinPost != null)
                {
                    movieCheckinPosts.Add(movieCheckinPost);
                    movieCheckinPost = await movieCheckinPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return movieCheckinPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieCheckinPost>));
        }
    }
}
