namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowRequestArrayJsonReader : ArrayJsonReader<ITraktUserFollowRequest>
    {
        public override async Task<IEnumerable<ITraktUserFollowRequest>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowRequestReader = new UserFollowRequestObjectJsonReader();
                var userFollowRequests = new List<ITraktUserFollowRequest>();
                ITraktUserFollowRequest userFollowRequest = await userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollowRequest != null)
                {
                    userFollowRequests.Add(userFollowRequest);
                    userFollowRequest = await userFollowRequestReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userFollowRequests;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollowRequest>));
        }
    }
}
