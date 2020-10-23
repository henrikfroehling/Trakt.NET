namespace TraktNet.Objects.Post.Users.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListsReorderPostResponseArrayJsonReader : ArrayJsonReader<ITraktUserCustomListsReorderPostResponse>
    {
        public override async Task<IEnumerable<ITraktUserCustomListsReorderPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListsReorderPostResponseReader = new UserCustomListsReorderPostResponseObjectJsonReader();
                var userCustomListsReorderPostResponses = new List<ITraktUserCustomListsReorderPostResponse>();
                ITraktUserCustomListsReorderPostResponse userCustomListsReorderPostResponse = await userCustomListsReorderPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                while (userCustomListsReorderPostResponse != null)
                {
                    userCustomListsReorderPostResponses.Add(userCustomListsReorderPostResponse);
                    userCustomListsReorderPostResponse = await userCustomListsReorderPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                }

                return userCustomListsReorderPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListsReorderPostResponse>)).ConfigureAwait(false);
        }
    }
}
