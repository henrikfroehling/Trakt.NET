namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowRequestArrayJsonReader : AArrayJsonReader<ITraktUserFollowRequest>
    {
        public override async Task<IEnumerable<ITraktUserFollowRequest>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowRequestReader = new UserFollowRequestObjectJsonReader();
                //var userFollowRequestReadingTasks = new List<Task<ITraktUserFollowRequest>>();
                var userFollowRequests = new List<ITraktUserFollowRequest>();

                //userFollowRequestReadingTasks.Add(userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserFollowRequest userFollowRequest = await userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollowRequest != null)
                {
                    userFollowRequests.Add(userFollowRequest);
                    //userFollowRequestReadingTasks.Add(userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userFollowRequest = await userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserFollowRequests = await Task.WhenAll(userFollowRequestReadingTasks);
                //return (IEnumerable<ITraktUserFollowRequest>)readUserFollowRequests.GetEnumerator();
                return userFollowRequests;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));
        }
    }
}
