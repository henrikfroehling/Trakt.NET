namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Basic.Json.Reader;
    using Enums;
    using Episodes.Json.Reader;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Lists.Json.Reader;

    internal class UserCommentObjectJsonReader : AObjectJsonReader<ITraktUserComment>
    {
        public override async Task<ITraktUserComment> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var commentReader = new CommentObjectJsonReader();
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var listReader = new ListObjectJsonReader();
                ITraktUserComment traktUserComment = new TraktUserComment();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktUserComment.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktObjectType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            traktUserComment.Comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktUserComment.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktUserComment.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            traktUserComment.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            traktUserComment.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            traktUserComment.List = await listReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserComment;
            }

            return await Task.FromResult(default(ITraktUserComment));
        }
    }
}
