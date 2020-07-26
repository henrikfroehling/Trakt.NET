namespace TraktNet.Objects.Post.Users.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowUserPostResponseArrayJsonReader : ArrayJsonReader<ITraktUserFollowUserPostResponse>
    {
        public override async Task<IEnumerable<ITraktUserFollowUserPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserFollowUserPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userFollowUserPostResponseReader = new UserFollowUserPostResponseObjectJsonReader();
                var userFollowUserPostResponses = new List<ITraktUserFollowUserPostResponse>();
                ITraktUserFollowUserPostResponse userFollowUserPostResponse = await userFollowUserPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userFollowUserPostResponse != null)
                {
                    userFollowUserPostResponses.Add(userFollowUserPostResponse);
                    userFollowUserPostResponse = await userFollowUserPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userFollowUserPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserFollowUserPostResponse>));
        }
    }
}
