namespace TraktNet.Objects.Get.Ratings.Json.Reader
{
    using Enums;
    using Episodes.Json.Reader;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingsItemObjectJsonReader : AObjectJsonReader<ITraktRatingsItem>
    {
        public override async Task<ITraktRatingsItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktRatingsItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                var showObjectReader = new ShowObjectJsonReader();
                var seasonObjectReader = new SeasonObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();

                ITraktRatingsItem traktRatingItem = new TraktRatingsItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRatingItem.RatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_RATING:
                            traktRatingItem.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_TYPE:
                            traktRatingItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktRatingsItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_MOVIE:
                            traktRatingItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_SHOW:
                            traktRatingItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_SEASON:
                            traktRatingItem.Season = await seasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.RATINGS_ITEM_PROPERTY_NAME_EPISODE:
                            traktRatingItem.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRatingItem;
            }

            return await Task.FromResult(default(ITraktRatingsItem));
        }
    }
}
