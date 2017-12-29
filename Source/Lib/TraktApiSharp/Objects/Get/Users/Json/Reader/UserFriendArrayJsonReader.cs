namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFriendArrayJsonReader : AArrayJsonReader<ITraktUserFriend>
    {
        public override async Task<IEnumerable<ITraktUserFriend>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFriend>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFriendReader = new UserFriendObjectJsonReader();
                //var userFriendReadingTasks = new List<Task<ITraktUserFriend>>();
                var userFriends = new List<ITraktUserFriend>();

                //userFriendReadingTasks.Add(userFriendReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserFriend userFriend = await userFriendReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFriend != null)
                {
                    userFriends.Add(userFriend);
                    //userFriendReadingTasks.Add(userFriendReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userFriend = await userFriendReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserFriends = await Task.WhenAll(userFriendReadingTasks);
                //return (IEnumerable<ITraktUserFriend>)readUserFriends.GetEnumerator();
                return userFriends;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFriend>));
        }
    }
}
