namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseArrayJsonReader : AArrayJsonReader<ITraktUserCustomListItemsPostResponse>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostResponseReader = new UserCustomListItemsPostResponseObjectJsonReader();
                var userCustomListItemsPostResponses = new List<ITraktUserCustomListItemsPostResponse>();
                ITraktUserCustomListItemsPostResponse userCustomListItemsPostResponse = await userCustomListItemsPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostResponse != null)
                {
                    userCustomListItemsPostResponses.Add(userCustomListItemsPostResponse);
                    userCustomListItemsPostResponse = await userCustomListItemsPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostResponse>));
        }
    }
}
