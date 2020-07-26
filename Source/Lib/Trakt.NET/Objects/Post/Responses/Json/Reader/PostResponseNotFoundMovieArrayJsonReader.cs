namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundMovieArrayJsonReader : ArrayJsonReader<ITraktPostResponseNotFoundMovie>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundMovieObjectReader = new PostResponseNotFoundMovieObjectJsonReader();
                var postResponseNotFoundMovies = new List<ITraktPostResponseNotFoundMovie>();
                ITraktPostResponseNotFoundMovie postResponseNotFoundMovie = await postResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundMovie != null)
                {
                    postResponseNotFoundMovies.Add(postResponseNotFoundMovie);
                    postResponseNotFoundMovie = await postResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return postResponseNotFoundMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));
        }
    }
}
