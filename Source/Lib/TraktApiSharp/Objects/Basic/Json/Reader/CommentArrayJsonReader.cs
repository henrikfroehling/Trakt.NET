namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentArrayJsonReader : IArrayJsonReader<ITraktComment>
    {
        public Task<IEnumerable<ITraktComment>> ReadArrayAsync(string json, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktComment>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktComment>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktComment>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktComment>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktComment>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentReader = new CommentObjectJsonReader();
                //var commentReadingTasks = new List<Task<ITraktComment>>();
                var comments = new List<ITraktComment>();

                //commentReadingTasks.Add(commentReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktComment comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (comment != null)
                {
                    comments.Add(comment);
                    //commentReadingTasks.Add(commentReader.ReadObjectAsync(jsonReader, cancellationToken));
                    comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readComments = await Task.WhenAll(commentReadingTasks);
                //return (IEnumerable<ITraktComment>)readComments.GetEnumerator();
                return comments;
            }

            return await Task.FromResult(default(IEnumerable<ITraktComment>));
        }
    }
}
