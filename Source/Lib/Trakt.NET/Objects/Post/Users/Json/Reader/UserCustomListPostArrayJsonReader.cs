namespace TraktNet.Objects.Post.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListPostArrayJsonReader : AArrayJsonReader<ITraktUserCustomListPost>
    {
        public override async Task<IEnumerable<ITraktUserCustomListPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListPostReader = new UserCustomListPostObjectJsonReader();
                var userCustomListPosts = new List<ITraktUserCustomListPost>();
                ITraktUserCustomListPost userCustomListPost = await userCustomListPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListPost != null)
                {
                    userCustomListPosts.Add(userCustomListPost);
                    userCustomListPost = await userCustomListPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListPost>));
        }
    }
}
