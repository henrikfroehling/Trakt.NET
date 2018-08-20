namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostShowArrayJsonReader : AArrayJsonReader<ITraktUserHiddenItemsPostShow>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostShowReader = new UserHiddenItemsPostShowObjectJsonReader();
                var userHiddenItemsPostShows = new List<ITraktUserHiddenItemsPostShow>();
                ITraktUserHiddenItemsPostShow userHiddenItemsPostShow = await userHiddenItemsPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostShow != null)
                {
                    userHiddenItemsPostShows.Add(userHiddenItemsPostShow);
                    userHiddenItemsPostShow = await userHiddenItemsPostShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostShow>));
        }
    }
}
