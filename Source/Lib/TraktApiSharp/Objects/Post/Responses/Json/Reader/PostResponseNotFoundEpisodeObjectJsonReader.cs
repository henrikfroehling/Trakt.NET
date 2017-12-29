namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Get.Episodes.Json.Reader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundEpisodeObjectJsonReader : AObjectJsonReader<ITraktPostResponseNotFoundEpisode>
    {
        public override async Task<ITraktPostResponseNotFoundEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPostResponseNotFoundEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsReader = new EpisodeIdsObjectJsonReader();
                ITraktPostResponseNotFoundEpisode postResponseNotFoundEpisode = new TraktPostResponseNotFoundEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_IDS:
                            postResponseNotFoundEpisode.Ids = await episodeIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return postResponseNotFoundEpisode;
            }

            return await Task.FromResult(default(ITraktPostResponseNotFoundEpisode));
        }
    }
}
