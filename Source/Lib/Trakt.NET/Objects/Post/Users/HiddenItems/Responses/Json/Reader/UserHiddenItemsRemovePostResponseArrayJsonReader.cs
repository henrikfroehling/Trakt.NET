namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsRemovePostResponseArrayJsonReader : AArrayJsonReader<ITraktUserHiddenItemsRemovePostResponse>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsRemovePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsRemovePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsRemovePostResponseReader = new UserHiddenItemsRemovePostResponseObjectJsonReader();
                var userHiddenItemsRemovePostResponses = new List<ITraktUserHiddenItemsRemovePostResponse>();
                ITraktUserHiddenItemsRemovePostResponse userHiddenItemsRemovePostResponse = await userHiddenItemsRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsRemovePostResponse != null)
                {
                    userHiddenItemsRemovePostResponses.Add(userHiddenItemsRemovePostResponse);
                    userHiddenItemsRemovePostResponse = await userHiddenItemsRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsRemovePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsRemovePostResponse>));
        }
    }
}
