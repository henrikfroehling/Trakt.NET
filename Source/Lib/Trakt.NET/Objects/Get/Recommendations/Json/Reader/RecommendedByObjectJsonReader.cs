namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Json.Reader;

    internal class RecommendedByObjectJsonReader : AObjectJsonReader<ITraktRecommendedBy>
    {
        public override async Task<ITraktRecommendedBy> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userObjectReader = new UserObjectJsonReader();
                ITraktRecommendedBy traktRecommendedBy = new TraktRecommendedBy();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_USER:
                            traktRecommendedBy.User = await userObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            traktRecommendedBy.Notes = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRecommendedBy;
            }

            return await Task.FromResult(default(ITraktRecommendedBy));
        }
    }
}
