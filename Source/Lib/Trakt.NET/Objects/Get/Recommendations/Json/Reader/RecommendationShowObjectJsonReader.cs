namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationShowObjectJsonReader : ARecommendationObjectJsonReader<ITraktRecommendationShow>
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
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktRecommendationShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await ReadAsync(jsonReader, traktRecommendationShow, propertyName, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktRecommendationShow;
            }

            return await Task.FromResult(default(ITraktRecommendationShow));
        }
    }
}
