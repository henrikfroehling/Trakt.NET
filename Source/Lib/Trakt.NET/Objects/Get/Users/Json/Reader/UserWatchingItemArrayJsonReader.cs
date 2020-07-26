namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserWatchingItemArrayJsonReader : ArrayJsonReader<ITraktUserWatchingItem>
    {
        public override async Task<IEnumerable<ITraktUserWatchingItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserWatchingItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userWatchingItemReader = new UserWatchingItemObjectJsonReader();
                var userWatchingItems = new List<ITraktUserWatchingItem>();
                ITraktUserWatchingItem userWatchingItem = await userWatchingItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userWatchingItem != null)
                {
                    userWatchingItems.Add(userWatchingItem);
                    userWatchingItem = await userWatchingItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userWatchingItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserWatchingItem>));
        }
    }
}
