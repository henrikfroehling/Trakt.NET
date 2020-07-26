namespace TraktNet.Objects.Post.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListsReorderPostArrayJsonReader : ArrayJsonReader<ITraktUserCustomListsReorderPost>
    {
        public override async Task<IEnumerable<ITraktUserCustomListsReorderPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListsReorderPost>)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListsReorderPostReader = new UserCustomListsReorderPostObjectJsonReader();
                var userCustomListsReorderPosts = new List<ITraktUserCustomListsReorderPost>();
                ITraktUserCustomListsReorderPost userCustomListsReorderPost = await userCustomListsReorderPostReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                while (userCustomListsReorderPost != null)
                {
                    userCustomListsReorderPosts.Add(userCustomListsReorderPost);
                    userCustomListsReorderPost = await userCustomListsReorderPostReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                }

                return userCustomListsReorderPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListsReorderPost>)).ConfigureAwait(false);
        }
    }
}
