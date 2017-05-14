namespace TraktApiSharp.Objects.Get.Ratings.JsonReader
{
    using Enums;
    using Episodes.JsonReader;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Ratings.Implementations;
    using Seasons.JsonReader;
    using Shows.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktRatingsItemObjectJsonReader : ITraktObjectJsonReader<ITraktRatingsItem>
    {
        private const string PROPERTY_NAME_RATED_AT = "rated_at";
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_SEASON = "season";
        private const string PROPERTY_NAME_EPISODE = "episode";

        public Task<ITraktRatingsItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktRatingsItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktRatingsItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktRatingsItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktRatingsItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktRatingsItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new TraktMovieObjectJsonReader();
                var showObjectReader = new ITraktShowObjectJsonReader();
                var seasonObjectReader = new ITraktSeasonObjectJsonReader();
                var episodeObjectReader = new TraktEpisodeObjectJsonReader();

                ITraktRatingsItem traktRatingItem = new TraktRatingsItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRatingItem.RatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_RATING:
                            traktRatingItem.Rating = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_TYPE:
                            traktRatingItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktRatingsItemType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktRatingItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktRatingItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASON:
                            traktRatingItem.Season = await seasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
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
