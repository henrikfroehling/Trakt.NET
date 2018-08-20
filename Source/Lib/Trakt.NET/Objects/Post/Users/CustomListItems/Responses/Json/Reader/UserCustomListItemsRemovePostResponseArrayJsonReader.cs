namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsRemovePostResponseArrayJsonReader : AArrayJsonReader<ITraktUserCustomListItemsRemovePostResponse>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsRemovePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsRemovePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsRemovePostResponseReader = new UserCustomListItemsRemovePostResponseObjectJsonReader();
                var userCustomListItemsRemovePostResponses = new List<ITraktUserCustomListItemsRemovePostResponse>();
                ITraktUserCustomListItemsRemovePostResponse userCustomListItemsRemovePostResponse = await userCustomListItemsRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsRemovePostResponse != null)
                {
                    userCustomListItemsRemovePostResponses.Add(userCustomListItemsRemovePostResponse);
                    userCustomListItemsRemovePostResponse = await userCustomListItemsRemovePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsRemovePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsRemovePostResponse>));
        }
    }
}
