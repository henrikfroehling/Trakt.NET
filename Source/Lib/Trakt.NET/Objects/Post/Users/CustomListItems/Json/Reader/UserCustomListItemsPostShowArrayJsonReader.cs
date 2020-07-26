namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostShowArrayJsonReader : ArrayJsonReader<ITraktUserCustomListItemsPostShow>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostShowReader = new UserCustomListItemsPostShowObjectJsonReader();
                var userCustomListItemsPostShows = new List<ITraktUserCustomListItemsPostShow>();
                ITraktUserCustomListItemsPostShow userCustomListItemsPostShow = await userCustomListItemsPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostShow != null)
                {
                    userCustomListItemsPostShows.Add(userCustomListItemsPostShow);
                    userCustomListItemsPostShow = await userCustomListItemsPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostShow>));
        }
    }
}
