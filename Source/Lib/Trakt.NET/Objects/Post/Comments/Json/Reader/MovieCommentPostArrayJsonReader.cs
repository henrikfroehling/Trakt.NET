namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCommentPostArrayJsonReader : ArrayJsonReader<ITraktMovieCommentPost>
    {
        public override async Task<IEnumerable<ITraktMovieCommentPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieCommentPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieCommentPostReader = new MovieCommentPostObjectJsonReader();
                var movieCommentPosts = new List<ITraktMovieCommentPost>();
                ITraktMovieCommentPost movieCommentPost = await movieCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (movieCommentPost != null)
                {
                    movieCommentPosts.Add(movieCommentPost);
                    movieCommentPost = await movieCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return movieCommentPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieCommentPost>));
        }
    }
}
