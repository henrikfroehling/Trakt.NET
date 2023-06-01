namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Enums;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationObjectJsonReader : AObjectJsonReader<ITraktRecommendation>
    {
        public override async Task<ITraktRecommendation> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktRecommendation traktRecommendation = new TraktRecommendation();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecommendation.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RANK:
                            traktRecommendation.Rank = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                                if (value.First)
                                    traktRecommendation.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktRecommendation.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktRecommendationObjectType>(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            traktRecommendation.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            {
                                var movieObjectReader = new MovieObjectJsonReader();
                                traktRecommendation.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            {
                                var showObjectReader = new ShowObjectJsonReader();
                                traktRecommendation.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktRecommendation;
            }

            return await Task.FromResult(default(ITraktRecommendation));
        }
    }
}
