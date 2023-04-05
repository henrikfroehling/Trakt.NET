namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Shows.Json.Reader;

    internal class RecommendedShowObjectJsonReader : AShowObjectJsonReader<ITraktRecommendedShow>
    {
        protected override ITraktRecommendedShow CreateShowObject() => new TraktRecommendedShow();
        
        protected override async Task ReadPropertyAsync(JsonTextReader jsonReader, ITraktRecommendedShow show, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_RECOMMENDED_BY:
                    var recommendedByArrayReader = new ArrayJsonReader<ITraktRecommendedBy>();
                    show.RecommendedBy = await recommendedByArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                    break;
                default:
                    await base.ReadPropertyAsync(jsonReader, show, propertyName, cancellationToken);
                    break;
            }
        }
    }
}
