namespace TraktApiSharp.Objects.Get.Users.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLikeItemArrayJsonReader : IArrayJsonReader<ITraktUserLikeItem>
    {
        public Task<IEnumerable<ITraktUserLikeItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktUserLikeItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktUserLikeItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userLikeItemReader = new UserLikeItemObjectJsonReader();
                //var userLikeItemReadingTasks = new List<Task<ITraktUserLikeItem>>();
                var userLikeItems = new List<ITraktUserLikeItem>();

                //userLikeItemReadingTasks.Add(userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserLikeItem userLikeItem = await userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userLikeItem != null)
                {
                    userLikeItems.Add(userLikeItem);
                    //userLikeItemReadingTasks.Add(userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userLikeItem = await userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserLikeItems = await Task.WhenAll(userLikeItemReadingTasks);
                //return (IEnumerable<ITraktUserLikeItem>)readUserLikeItems.GetEnumerator();
                return userLikeItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));
        }
    }
}
