namespace TraktNet.Objects.Post.Checkins.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCheckinPostArrayJsonReader : ArrayJsonReader<ITraktEpisodeCheckinPost>
    {
        public override async Task<IEnumerable<ITraktEpisodeCheckinPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeCheckinPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeCheckinPostReader = new EpisodeCheckinPostObjectJsonReader();
                var episodeCheckinPosts = new List<ITraktEpisodeCheckinPost>();
                ITraktEpisodeCheckinPost episodeCheckinPost = await episodeCheckinPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (episodeCheckinPost != null)
                {
                    episodeCheckinPosts.Add(episodeCheckinPost);
                    episodeCheckinPost = await episodeCheckinPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return episodeCheckinPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeCheckinPost>));
        }
    }
}
