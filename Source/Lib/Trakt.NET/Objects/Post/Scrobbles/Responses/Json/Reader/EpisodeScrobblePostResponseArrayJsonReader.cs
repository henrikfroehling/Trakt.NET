namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeScrobblePostResponseArrayJsonReader : ArrayJsonReader<ITraktEpisodeScrobblePostResponse>
    {
        public override async Task<IEnumerable<ITraktEpisodeScrobblePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeScrobblePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeScrobblePostResponseReader = new EpisodeScrobblePostResponseObjectJsonReader();
                var episodeScrobblePostResponses = new List<ITraktEpisodeScrobblePostResponse>();
                ITraktEpisodeScrobblePostResponse episodeScrobblePostResponse = await episodeScrobblePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (episodeScrobblePostResponse != null)
                {
                    episodeScrobblePostResponses.Add(episodeScrobblePostResponse);
                    episodeScrobblePostResponse = await episodeScrobblePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return episodeScrobblePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeScrobblePostResponse>));
        }
    }
}
