namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseNotFoundGroupArrayJsonReader : AArrayJsonReader<ITraktUserHiddenItemsPostResponseNotFoundGroup>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostResponseNotFoundGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostResponseNotFoundGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostResponseNotFoundGroupReader = new UserHiddenItemsPostResponseNotFoundGroupObjectJsonReader();
                var userHiddenItemsPostResponseNotFoundGroups = new List<ITraktUserHiddenItemsPostResponseNotFoundGroup>();
                ITraktUserHiddenItemsPostResponseNotFoundGroup userHiddenItemsPostResponseNotFoundGroup = await userHiddenItemsPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostResponseNotFoundGroup != null)
                {
                    userHiddenItemsPostResponseNotFoundGroups.Add(userHiddenItemsPostResponseNotFoundGroup);
                    userHiddenItemsPostResponseNotFoundGroup = await userHiddenItemsPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostResponseNotFoundGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostResponseNotFoundGroup>));
        }
    }
}
