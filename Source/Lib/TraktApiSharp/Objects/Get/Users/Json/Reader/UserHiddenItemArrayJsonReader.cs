namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemArrayJsonReader : IArrayJsonReader<ITraktUserHiddenItem>
    {
        public Task<IEnumerable<ITraktUserHiddenItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUserHiddenItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUserHiddenItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUserHiddenItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUserHiddenItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemReader = new UserHiddenItemObjectJsonReader();
                //var userHiddenItemReadingTasks = new List<Task<ITraktUserHiddenItem>>();
                var userHiddenItems = new List<ITraktUserHiddenItem>();

                //userHiddenItemReadingTasks.Add(userHiddenItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserHiddenItem userHiddenItem = await userHiddenItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItem != null)
                {
                    userHiddenItems.Add(userHiddenItem);
                    //userHiddenItemReadingTasks.Add(userHiddenItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userHiddenItem = await userHiddenItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserHiddenItems = await Task.WhenAll(userHiddenItemReadingTasks);
                //return (IEnumerable<ITraktUserHiddenItem>)readUserHiddenItems.GetEnumerator();
                return userHiddenItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItem>));
        }
    }
}
