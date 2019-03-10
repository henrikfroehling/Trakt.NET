namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLikeItemArrayJsonReader : AArrayJsonReader<ITraktUserLikeItem>
    {
        public override async Task<IEnumerable<ITraktUserLikeItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userLikeItemReader = new UserLikeItemObjectJsonReader();
                var userLikeItems = new List<ITraktUserLikeItem>();
                ITraktUserLikeItem userLikeItem = await userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userLikeItem != null)
                {
                    userLikeItems.Add(userLikeItem);
                    userLikeItem = await userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userLikeItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));
        }
    }
}
