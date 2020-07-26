namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostShowEpisodeArrayJsonReader : ArrayJsonReader<ITraktUserCustomListItemsPostShowEpisode>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostShowEpisodeReader = new UserCustomListItemsPostShowEpisodeObjectJsonReader();
                var userCustomListItemsPostShowEpisodes = new List<ITraktUserCustomListItemsPostShowEpisode>();
                ITraktUserCustomListItemsPostShowEpisode userCustomListItemsPostShowEpisode = await userCustomListItemsPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostShowEpisode != null)
                {
                    userCustomListItemsPostShowEpisodes.Add(userCustomListItemsPostShowEpisode);
                    userCustomListItemsPostShowEpisode = await userCustomListItemsPostShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostShowEpisode>));
        }
    }
}
