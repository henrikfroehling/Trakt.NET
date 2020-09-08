namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationShowObjectJsonReader : AObjectJsonReader<ITraktRecommendationShow>
    {
        public override async Task<ITraktRecommendationShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                ITraktRecommendationShow traktRecommendationShow = new TraktRecommendationShow();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RANK:
                            traktRecommendationShow.Rank = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false); ;
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken).ConfigureAwait(false); ;

                                if (value.First)
                                    traktRecommendationShow.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktRecommendationShow.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktRecommendationObjectType>(jsonReader, cancellationToken).ConfigureAwait(false); ;
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            traktRecommendationShow.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktRecommendationShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false); ;
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false); ;
                            break;
                    }
                }

                return traktRecommendationShow;
            }

            return await Task.FromResult(default(ITraktRecommendationShow));
        }
    }
}
