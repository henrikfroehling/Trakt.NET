namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendedShowObjectJsonReader : AShowObjectJsonReader<ITraktRecommendedShow>
    {
        protected override ITraktRecommendedShow CreateShowObject() => new TraktRecommendedShow();
        
        protected override async Task ReadPropertyAsync(JsonTextReader jsonReader, ITraktRecommendedShow show, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_FAVORITED_BY:
                    var favoritedByArrayReader = new ArrayJsonReader<ITraktFavoritedBy>();
                    show.FavoritedBy = await favoritedByArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                    break;
                default:
                    await base.ReadPropertyAsync(jsonReader, show, propertyName, cancellationToken);
                    break;
            }
        }
    }
}
