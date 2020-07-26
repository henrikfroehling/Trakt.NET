namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemArrayJsonReader : ArrayJsonReader<ITraktUserHiddenItem>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemReader = new UserHiddenItemObjectJsonReader();
                var userHiddenItems = new List<ITraktUserHiddenItem>();
                ITraktUserHiddenItem userHiddenItem = await userHiddenItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItem != null)
                {
                    userHiddenItems.Add(userHiddenItem);
                    userHiddenItem = await userHiddenItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItem>));
        }
    }
}
