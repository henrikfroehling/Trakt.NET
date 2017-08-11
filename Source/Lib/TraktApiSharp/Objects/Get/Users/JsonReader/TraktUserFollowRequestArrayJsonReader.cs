namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserFollowRequestArrayJsonReader : ITraktArrayJsonReader<ITraktUserFollowRequest>
    {
        public Task<IEnumerable<ITraktUserFollowRequest>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUserFollowRequest>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUserFollowRequest>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowRequestReader = new TraktUserFollowRequestObjectJsonReader();
                //var userFollowRequestReadingTasks = new List<Task<ITraktUserFollowRequest>>();
                var userFollowRequests = new List<ITraktUserFollowRequest>();

                //userFollowRequestReadingTasks.Add(userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserFollowRequest userFollowRequest = await userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollowRequest != null)
                {
                    userFollowRequests.Add(userFollowRequest);
                    //userFollowRequestReadingTasks.Add(userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userFollowRequest = await userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserFollowRequests = await Task.WhenAll(userFollowRequestReadingTasks);
                //return (IEnumerable<ITraktUserFollowRequest>)readUserFollowRequests.GetEnumerator();
                return userFollowRequests;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));
        }
    }
}
