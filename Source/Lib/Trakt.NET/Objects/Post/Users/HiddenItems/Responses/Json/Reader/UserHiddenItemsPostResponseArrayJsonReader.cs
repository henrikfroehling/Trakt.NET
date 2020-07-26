namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseArrayJsonReader : ArrayJsonReader<ITraktUserHiddenItemsPostResponse>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostResponseReader = new UserHiddenItemsPostResponseObjectJsonReader();
                var userHiddenItemsPostResponses = new List<ITraktUserHiddenItemsPostResponse>();
                ITraktUserHiddenItemsPostResponse userHiddenItemsPostResponse = await userHiddenItemsPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostResponse != null)
                {
                    userHiddenItemsPostResponses.Add(userHiddenItemsPostResponse);
                    userHiddenItemsPostResponse = await userHiddenItemsPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostResponse>));
        }
    }
}
