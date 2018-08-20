namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseNotFoundGroupArrayJsonReader : AArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostResponseNotFoundGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostResponseNotFoundGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostResponseNotFoundGroupReader = new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();
                var userCustomListItemsPostResponseNotFoundGroups = new List<ITraktUserCustomListItemsPostResponseNotFoundGroup>();
                ITraktUserCustomListItemsPostResponseNotFoundGroup userCustomListItemsPostResponseNotFoundGroup = await userCustomListItemsPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostResponseNotFoundGroup != null)
                {
                    userCustomListItemsPostResponseNotFoundGroups.Add(userCustomListItemsPostResponseNotFoundGroup);
                    userCustomListItemsPostResponseNotFoundGroup = await userCustomListItemsPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostResponseNotFoundGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostResponseNotFoundGroup>));
        }
    }
}
