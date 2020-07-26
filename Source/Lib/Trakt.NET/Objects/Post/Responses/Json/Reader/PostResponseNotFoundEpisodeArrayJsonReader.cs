namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundEpisodeArrayJsonReader : ArrayJsonReader<ITraktPostResponseNotFoundEpisode>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundEpisodeObjectReader = new PostResponseNotFoundEpisodeObjectJsonReader();
                var postResponseNotFoundEpisodes = new List<ITraktPostResponseNotFoundEpisode>();
                ITraktPostResponseNotFoundEpisode postResponseNotFoundEpisode = await postResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundEpisode != null)
                {
                    postResponseNotFoundEpisodes.Add(postResponseNotFoundEpisode);
                    postResponseNotFoundEpisode = await postResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return postResponseNotFoundEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundEpisode>));
        }
    }
}
