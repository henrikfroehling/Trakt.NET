namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundShowArrayJsonReader : IArrayJsonReader<ITraktPostResponseNotFoundShow>
    {
        public Task<IEnumerable<ITraktPostResponseNotFoundShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPostResponseNotFoundShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPostResponseNotFoundShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundShowObjectReader = new PostResponseNotFoundShowObjectJsonReader();
                //var postResponseNotFoundShowReadingTasks = new List<Task<ITraktPostResponseNotFoundShow>>();
                var postResponseNotFoundShows = new List<ITraktPostResponseNotFoundShow>();

                //postResponseNotFoundShowReadingTasks.Add(postResponseNotFoundShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundShow postResponseNotFoundShow = await postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundShow != null)
                {
                    postResponseNotFoundShows.Add(postResponseNotFoundShow);
                    //postResponseNotFoundShowReadingTasks.Add(postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundShow = await postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundShows = await Task.WhenAll(postResponseNotFoundShowReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundShow>)readPostResponseNotFoundShows.GetEnumerator();
                return postResponseNotFoundShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));
        }
    }
}
