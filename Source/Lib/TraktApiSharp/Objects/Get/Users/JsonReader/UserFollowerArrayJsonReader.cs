namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowerArrayJsonReader : IArrayJsonReader<ITraktUserFollower>
    {
        public Task<IEnumerable<ITraktUserFollower>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUserFollower>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUserFollower>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUserFollower>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUserFollower>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollower>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowerReader = new UserFollowerObjectJsonReader();
                //var userFollowerReadingTasks = new List<Task<ITraktUserFollower>>();
                var userFollowers = new List<ITraktUserFollower>();

                //userFollowerReadingTasks.Add(userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserFollower userFollower = await userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollower != null)
                {
                    userFollowers.Add(userFollower);
                    //userFollowerReadingTasks.Add(userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userFollower = await userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserFollowers = await Task.WhenAll(userFollowerReadingTasks);
                //return (IEnumerable<ITraktUserFollower>)readUserFollowers.GetEnumerator();
                return userFollowers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollower>));
        }
    }
}
