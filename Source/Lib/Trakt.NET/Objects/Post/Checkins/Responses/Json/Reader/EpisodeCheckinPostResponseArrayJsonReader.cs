namespace TraktNet.Objects.Post.Checkins.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCheckinPostResponseArrayJsonReader : ArrayJsonReader<ITraktEpisodeCheckinPostResponse>
    {
        public override async Task<IEnumerable<ITraktEpisodeCheckinPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeCheckinPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeCheckinPostResponseReader = new EpisodeCheckinPostResponseObjectJsonReader();
                var episodeCheckinPostResponses = new List<ITraktEpisodeCheckinPostResponse>();
                ITraktEpisodeCheckinPostResponse episodeCheckinPostResponse = await episodeCheckinPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (episodeCheckinPostResponse != null)
                {
                    episodeCheckinPostResponses.Add(episodeCheckinPostResponse);
                    episodeCheckinPostResponse = await episodeCheckinPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return episodeCheckinPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeCheckinPostResponse>));
        }
    }
}
