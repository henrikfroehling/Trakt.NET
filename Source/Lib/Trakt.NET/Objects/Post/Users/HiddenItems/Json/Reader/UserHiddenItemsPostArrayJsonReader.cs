namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostArrayJsonReader : AArrayJsonReader<ITraktUserHiddenItemsPost>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostReader = new UserHiddenItemsPostObjectJsonReader();
                var userHiddenItemsPosts = new List<ITraktUserHiddenItemsPost>();
                ITraktUserHiddenItemsPost userHiddenItemsPost = await userHiddenItemsPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPost != null)
                {
                    userHiddenItemsPosts.Add(userHiddenItemsPost);
                    userHiddenItemsPost = await userHiddenItemsPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPost>));
        }
    }
}
