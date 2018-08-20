namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseGroupArrayJsonReader : AArrayJsonReader<ITraktUserHiddenItemsPostResponseGroup>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostResponseGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostResponseGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostResponseGroupReader = new UserHiddenItemsPostResponseGroupObjectJsonReader();
                var userHiddenItemsPostResponseGroups = new List<ITraktUserHiddenItemsPostResponseGroup>();
                ITraktUserHiddenItemsPostResponseGroup userHiddenItemsPostResponseGroup = await userHiddenItemsPostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostResponseGroup != null)
                {
                    userHiddenItemsPostResponseGroups.Add(userHiddenItemsPostResponseGroup);
                    userHiddenItemsPostResponseGroup = await userHiddenItemsPostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostResponseGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostResponseGroup>));
        }
    }
}
