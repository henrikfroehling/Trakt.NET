namespace TraktApiSharp.Objects.Post.Responses.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktPostResponseNotFoundMovieArrayJsonReader : IArrayJsonReader<ITraktPostResponseNotFoundMovie>
    {
        public Task<IEnumerable<ITraktPostResponseNotFoundMovie>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPostResponseNotFoundMovie>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPostResponseNotFoundMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundMovieObjectReader = new TraktPostResponseNotFoundMovieObjectJsonReader();
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
