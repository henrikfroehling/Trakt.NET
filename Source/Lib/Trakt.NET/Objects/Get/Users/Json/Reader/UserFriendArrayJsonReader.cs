namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFriendArrayJsonReader : ArrayJsonReader<ITraktUserFriend>
    {
        public override async Task<IEnumerable<ITraktUserFriend>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFriend>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFriendReader = new UserFriendObjectJsonReader();
                var userFriends = new List<ITraktUserFriend>();
                ITraktUserFriend userFriend = await userFriendReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFriend != null)
                {
                    userFriends.Add(userFriend);
                    userFriend = await userFriendReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userFriends;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFriend>));
        }
    }
}
