namespace TraktNet.Objects.Post.Scrobbles.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeScrobblePostArrayJsonReader : AArrayJsonReader<ITraktEpisodeScrobblePost>
    {
        public override async Task<IEnumerable<ITraktEpisodeScrobblePost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeScrobblePost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeScrobblePostReader = new EpisodeScrobblePostObjectJsonReader();
                var episodeScrobblePosts = new List<ITraktEpisodeScrobblePost>();
                ITraktEpisodeScrobblePost episodeScrobblePost = await episodeScrobblePostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (episodeScrobblePost != null)
                {
                    episodeScrobblePosts.Add(episodeScrobblePost);
                    episodeScrobblePost = await episodeScrobblePostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return episodeScrobblePosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeScrobblePost>));
        }
    }
}
