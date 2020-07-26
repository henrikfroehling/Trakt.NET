namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostSeasonArrayJsonReader : ArrayJsonReader<ITraktUserHiddenItemsPostSeason>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostSeasonReader = new UserHiddenItemsPostSeasonObjectJsonReader();
                var userHiddenItemsPostSeasons = new List<ITraktUserHiddenItemsPostSeason>();
                ITraktUserHiddenItemsPostSeason userHiddenItemsPostSeason = await userHiddenItemsPostSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostSeason != null)
                {
                    userHiddenItemsPostSeasons.Add(userHiddenItemsPostSeason);
                    userHiddenItemsPostSeason = await userHiddenItemsPostSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostSeason>));
        }
    }
}
