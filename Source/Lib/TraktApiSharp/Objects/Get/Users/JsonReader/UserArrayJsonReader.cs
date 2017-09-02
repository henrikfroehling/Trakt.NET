namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserArrayJsonReader : IArrayJsonReader<ITraktUser>
    {
        public Task<IEnumerable<ITraktUser>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUser>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUser>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUser>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUser>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUser>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userReader = new TraktUserObjectJsonReader();
                //var userReadingTasks = new List<Task<ITraktUser>>();
                var users = new List<ITraktUser>();

                //userReadingTasks.Add(userReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUser user = await userReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (user != null)
                {
                    users.Add(user);
                    //userReadingTasks.Add(userReader.ReadObjectAsync(jsonReader, cancellationToken));
                    user = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUsers = await Task.WhenAll(userReadingTasks);
                //return (IEnumerable<ITraktUser>)readUsers.GetEnumerator();
                return users;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUser>));
        }
    }
}
