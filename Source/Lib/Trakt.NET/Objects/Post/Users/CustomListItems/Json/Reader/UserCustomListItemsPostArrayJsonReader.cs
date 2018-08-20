namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostArrayJsonReader : AArrayJsonReader<ITraktUserCustomListItemsPost>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostReader = new UserCustomListItemsPostObjectJsonReader();
                var userCustomListItemsPosts = new List<ITraktUserCustomListItemsPost>();
                ITraktUserCustomListItemsPost userCustomListItemsPost = await userCustomListItemsPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPost != null)
                {
                    userCustomListItemsPosts.Add(userCustomListItemsPost);
                    userCustomListItemsPost = await userCustomListItemsPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPost>));
        }
    }
}
