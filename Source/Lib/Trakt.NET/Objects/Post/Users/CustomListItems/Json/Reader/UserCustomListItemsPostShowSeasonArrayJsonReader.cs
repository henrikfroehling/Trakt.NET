namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostShowSeasonArrayJsonReader : ArrayJsonReader<ITraktUserCustomListItemsPostShowSeason>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostShowSeasonReader = new UserCustomListItemsPostShowSeasonObjectJsonReader();
                var userCustomListItemsPostShowSeasons = new List<ITraktUserCustomListItemsPostShowSeason>();
                ITraktUserCustomListItemsPostShowSeason userCustomListItemsPostShowSeason = await userCustomListItemsPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostShowSeason != null)
                {
                    userCustomListItemsPostShowSeasons.Add(userCustomListItemsPostShowSeason);
                    userCustomListItemsPostShowSeason = await userCustomListItemsPostShowSeasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostShowSeason>));
        }
    }
}
