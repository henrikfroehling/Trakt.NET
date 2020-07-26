namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowerArrayJsonReader : ArrayJsonReader<ITraktUserFollower>
    {
        public override async Task<IEnumerable<ITraktUserFollower>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollower>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowerReader = new UserFollowerObjectJsonReader();
                var userFollowers = new List<ITraktUserFollower>();
                ITraktUserFollower userFollower = await userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollower != null)
                {
                    userFollowers.Add(userFollower);
                    userFollower = await userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userFollowers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollower>));
        }
    }
}
