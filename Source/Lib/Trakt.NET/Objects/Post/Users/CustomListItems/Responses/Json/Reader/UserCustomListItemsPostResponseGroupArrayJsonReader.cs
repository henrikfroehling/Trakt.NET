namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseGroupArrayJsonReader : ArrayJsonReader<ITraktUserCustomListItemsPostResponseGroup>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostResponseGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostResponseGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostResponseGroupReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();
                var userCustomListItemsPostResponseGroups = new List<ITraktUserCustomListItemsPostResponseGroup>();
                ITraktUserCustomListItemsPostResponseGroup userCustomListItemsPostResponseGroup = await userCustomListItemsPostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostResponseGroup != null)
                {
                    userCustomListItemsPostResponseGroups.Add(userCustomListItemsPostResponseGroup);
                    userCustomListItemsPostResponseGroup = await userCustomListItemsPostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostResponseGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostResponseGroup>));
        }
    }
}
