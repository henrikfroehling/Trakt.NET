namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Basic.Json;
    using Basic.Json.Reader;
    using Enums;
    using Episodes.Json;
    using Episodes.Json.Reader;
    using Implementations;
    using Lists.Json;
    using Movies.Json;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json;
    using Seasons.Json.Reader;
    using Shows.Json;
    using Shows.Json.Reader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Lists.Json.Reader;

    internal class UserCommentObjectJsonReader : IObjectJsonReader<ITraktUserComment>
    {
        public Task<ITraktUserComment> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserComment));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserComment> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserComment));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserComment> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserComment));

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
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_TYPE:
                            traktUserComment.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktObjectType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_COMMENT:
                            traktUserComment.Comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_MOVIE:
                            traktUserComment.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_SHOW:
                            traktUserComment.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_SEASON:
                            traktUserComment.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_EPISODE:
                            traktUserComment.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_COMMENT_PROPERTY_NAME_LIST:
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
