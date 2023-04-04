namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Movies.Json.Reader;

    internal class RecommendedMovieObjectJsonReader : AMovieObjectJsonReader<ITraktRecommendedMovie>
    {
        protected override ITraktRecommendedMovie CreateMovieObject() => new TraktRecommendedMovie();
        
        protected override async Task ReadPropertyAsync(JsonTextReader jsonReader, ITraktRecommendedMovie movie, string propertyName, CancellationToken cancellationToken = default)
        {
            await base.ReadPropertyAsync(jsonReader, movie, propertyName, cancellationToken);

            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_RECOMMENDED_BY:
                    var recommendedByArrayReader = new ArrayJsonReader<ITraktRecommendedBy>();
                    movie.RecommendedBy = await recommendedByArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                    break;
                default:
                    await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                    break;
            }
        }
    }
}
