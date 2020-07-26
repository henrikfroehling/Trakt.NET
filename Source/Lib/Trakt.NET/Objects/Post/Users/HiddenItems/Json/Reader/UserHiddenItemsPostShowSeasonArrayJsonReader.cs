namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostShowSeasonArrayJsonReader : ArrayJsonReader<ITraktUserHiddenItemsPostShowSeason>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostShowSeasonReader = new UserHiddenItemsPostShowSeasonObjectJsonReader();
                var userHiddenItemsPostShowSeasons = new List<ITraktUserHiddenItemsPostShowSeason>();
                ITraktUserHiddenItemsPostShowSeason userHiddenItemsPostShowSeason = await userHiddenItemsPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostShowSeason != null)
                {
                    userHiddenItemsPostShowSeasons.Add(userHiddenItemsPostShowSeason);
                    userHiddenItemsPostShowSeason = await userHiddenItemsPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostShowSeason>));
        }
    }
}
