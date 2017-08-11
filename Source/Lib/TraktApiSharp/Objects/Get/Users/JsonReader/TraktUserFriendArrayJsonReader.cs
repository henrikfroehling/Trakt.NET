namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserFriendArrayJsonReader : ITraktArrayJsonReader<ITraktUserFriend>
    {
        public Task<IEnumerable<ITraktUserFriend>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUserFriend>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUserFriend>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUserFriend>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUserFriend>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFriend>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFriendReader = new TraktUserFriendObjectJsonReader();
                //var userFriendReadingTasks = new List<Task<ITraktUserFriend>>();
                var userFriends = new List<ITraktUserFriend>();

                //userFriendReadingTasks.Add(userFriendReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserFriend userFriend = await userFriendReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFriend != null)
                {
                    userFriends.Add(userFriend);
                    //userFriendReadingTasks.Add(userFriendReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userFriend = await userFriendReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserFriends = await Task.WhenAll(userFriendReadingTasks);
                //return (IEnumerable<ITraktUserFriend>)readUserFriends.GetEnumerator();
                return userFriends;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFriend>));
        }
    }
}
