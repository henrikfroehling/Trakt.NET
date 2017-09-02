namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCommentArrayJsonReader : IArrayJsonReader<ITraktUserComment>
    {
        public Task<IEnumerable<ITraktUserComment>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUserComment>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUserComment>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUserComment>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUserComment>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserComment>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCommentReader = new TraktUserCommentObjectJsonReader();
                //var userCommentReadingTasks = new List<Task<ITraktUserComment>>();
                var userComments = new List<ITraktUserComment>();

                //userCommentReadingTasks.Add(userCommentReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserComment userComment = await userCommentReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userComment != null)
                {
                    userComments.Add(userComment);
                    //userCommentReadingTasks.Add(userCommentReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userComment = await userCommentReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserComments = await Task.WhenAll(userCommentReadingTasks);
                //return (IEnumerable<ITraktUserComment>)readUserComments.GetEnumerator();
                return userComments;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserComment>));
        }
    }
}
