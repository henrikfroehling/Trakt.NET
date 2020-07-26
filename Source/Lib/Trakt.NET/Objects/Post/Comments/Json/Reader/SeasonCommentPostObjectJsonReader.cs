namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Basic.Json.Reader;
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCommentPostObjectJsonReader : AObjectJsonReader<ITraktSeasonCommentPost>
    {
        public override async Task<ITraktSeasonCommentPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSeasonCommentPost));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                ITraktSeasonCommentPost seasonCommentPost = new TraktSeasonCommentPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            seasonCommentPost.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            {
                                bool? value = await jsonReader.ReadAsBooleanAsync(cancellationToken);

                                if (value.HasValue)
                                    seasonCommentPost.Spoiler = value.Value;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            seasonCommentPost.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            seasonCommentPost.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return seasonCommentPost;
            }

            return await Task.FromResult(default(ITraktSeasonCommentPost));
        }
    }
}
