namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class ARecommendationObjectJsonReader<TRecommendationObjectType> : AObjectJsonReader<TRecommendationObjectType> where TRecommendationObjectType : ITraktRecommendation
    {
        protected async Task ReadAsync(JsonTextReader jsonReader, TRecommendationObjectType recommendationObject, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_RANK:
                    recommendationObject.Rank = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                    break;
                case JsonProperties.PROPERTY_NAME_LISTED_AT:
                    {
                        var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                        if (value.First)
                            recommendationObject.ListedAt = value.Second;

                        break;
                    }
                case JsonProperties.PROPERTY_NAME_TYPE:
                    recommendationObject.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktRecommendationObjectType>(jsonReader, cancellationToken).ConfigureAwait(false);
                    break;
                case JsonProperties.PROPERTY_NAME_NOTES:
                    recommendationObject.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    break;
                default:
                    await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                    break;
            }
        }
    }
}
