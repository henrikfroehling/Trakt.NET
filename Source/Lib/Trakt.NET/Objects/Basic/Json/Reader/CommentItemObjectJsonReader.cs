namespace TraktNet.Objects.Basic.Json.Reader
{
    using Enums;
    using Get.Episodes.Json.Reader;
    using Get.Movies.Json.Reader;
    using Get.Seasons.Json.Reader;
    using Get.Shows.Json.Reader;
    using Get.Users.Lists.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentItemObjectJsonReader : AObjectJsonReader<ITraktCommentItem>
    {
        public override async Task<ITraktCommentItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCommentItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktCommentItem traktCommentItem = new TraktCommentItem();
                var movieObjectJsonReader = new MovieObjectJsonReader();
                var showObjectJsonReader = new ShowObjectJsonReader();
                var seasonObjectJsonReader = new SeasonObjectJsonReader();
                var episodeObjectJsonReader = new EpisodeObjectJsonReader();
                var listObjectJsonReader = new ListObjectJsonReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktCommentItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktObjectType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktCommentItem.Movie = await movieObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktCommentItem.Show = await showObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            traktCommentItem.Season = await seasonObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            traktCommentItem.Episode = await episodeObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            traktCommentItem.List = await listObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCommentItem;
            }

            return await Task.FromResult(default(ITraktCommentItem));
        }
    }
}
