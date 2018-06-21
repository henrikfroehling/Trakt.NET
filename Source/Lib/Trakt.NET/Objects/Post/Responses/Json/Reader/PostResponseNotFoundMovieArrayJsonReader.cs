namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundMovieArrayJsonReader : AArrayJsonReader<ITraktPostResponseNotFoundMovie>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundMovieObjectReader = new PostResponseNotFoundMovieObjectJsonReader();
                //var postResponseNotFoundMovieReadingTasks = new List<Task<ITraktPostResponseNotFoundMovie>>();
                var postResponseNotFoundMovies = new List<ITraktPostResponseNotFoundMovie>();

                //postResponseNotFoundMovieReadingTasks.Add(postResponseNotFoundMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundMovie postResponseNotFoundMovie = await postResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundMovie != null)
                {
                    postResponseNotFoundMovies.Add(postResponseNotFoundMovie);
                    //postResponseNotFoundMovieReadingTasks.Add(postResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundMovie = await postResponseNotFoundMovieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundMovies = await Task.WhenAll(postResponseNotFoundMovieReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundMovie>)readPostResponseNotFoundMovies.GetEnumerator();
                return postResponseNotFoundMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));
        }
    }
}
