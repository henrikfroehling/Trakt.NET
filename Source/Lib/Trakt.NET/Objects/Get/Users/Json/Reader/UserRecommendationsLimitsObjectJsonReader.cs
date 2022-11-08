namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserRecommendationsLimitsObjectJsonReader : AObjectJsonReader<ITraktUserRecommendationsLimits>
    {
        public override async Task<ITraktUserRecommendationsLimits> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserRecommendationsLimits userRecommendationsLimits = new TraktUserRecommendationsLimits();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ITEM_COUNT:
                            userRecommendationsLimits.ItemCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userRecommendationsLimits;
            }

            return await Task.FromResult(default(ITraktUserRecommendationsLimits));
        }
    }
}
