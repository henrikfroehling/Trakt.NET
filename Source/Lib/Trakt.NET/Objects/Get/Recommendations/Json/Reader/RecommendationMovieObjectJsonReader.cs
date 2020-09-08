namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Enums;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationMovieObjectJsonReader : AObjectJsonReader<ITraktRecommendationMovie>
    {
        public override async Task<ITraktRecommendationMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                ITraktRecommendationMovie traktRecommendationMovie = new TraktRecommendationMovie();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RANK:
                            traktRecommendationMovie.Rank = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false); ;
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken).ConfigureAwait(false); ;

                                if (value.First)
                                    traktRecommendationMovie.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktRecommendationMovie.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktRecommendationObjectType>(jsonReader, cancellationToken).ConfigureAwait(false); ;
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            traktRecommendationMovie.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktRecommendationMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktRecommendationMovie;
            }

            return await Task.FromResult(default(ITraktRecommendationMovie));
        }
    }
}
