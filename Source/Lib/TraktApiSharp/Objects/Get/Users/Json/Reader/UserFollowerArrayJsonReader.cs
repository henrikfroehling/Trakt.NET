namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowerArrayJsonReader : AArrayJsonReader<ITraktUserFollower>
    {
        public override async Task<IEnumerable<ITraktUserFollower>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollower>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowerReader = new UserFollowerObjectJsonReader();
                //var userFollowerReadingTasks = new List<Task<ITraktUserFollower>>();
                var userFollowers = new List<ITraktUserFollower>();

                //userFollowerReadingTasks.Add(userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserFollower userFollower = await userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollower != null)
                {
                    userFollowers.Add(userFollower);
                    //userFollowerReadingTasks.Add(userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userFollower = await userFollowerReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserFollowers = await Task.WhenAll(userFollowerReadingTasks);
                //return (IEnumerable<ITraktUserFollower>)readUserFollowers.GetEnumerator();
                return userFollowers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollower>));
        }
    }
}
