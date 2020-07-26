namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Basic.Json.Reader;
    using Get.Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCommentPostObjectJsonReader : AObjectJsonReader<ITraktEpisodeCommentPost>
    {
        public override async Task<ITraktEpisodeCommentPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeCommentPost));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                ITraktEpisodeCommentPost episodeCommentPost = new TraktEpisodeCommentPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            episodeCommentPost.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            {
                                bool? value = await jsonReader.ReadAsBooleanAsync(cancellationToken);

                                if (value.HasValue)
                                    episodeCommentPost.Spoiler = value.Value;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            episodeCommentPost.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            episodeCommentPost.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return episodeCommentPost;
            }

            return await Task.FromResult(default(ITraktEpisodeCommentPost));
        }
    }
}
