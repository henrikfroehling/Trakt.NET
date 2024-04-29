namespace TraktNet.Objects.Get.Recommendations.Json.Reader
{
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendedMovieObjectJsonReader : AMovieObjectJsonReader<ITraktRecommendedMovie>
    {
        protected override ITraktRecommendedMovie CreateMovieObject() => new TraktRecommendedMovie();
        
        protected override async Task ReadPropertyAsync(JsonTextReader jsonReader, ITraktRecommendedMovie movie, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_FAVORITED_BY:
                    var favoritedByArrayReader = new ArrayJsonReader<ITraktFavoritedBy>();
                    movie.FavoritedBy = await favoritedByArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                    break;
                default:
                    await base.ReadPropertyAsync(jsonReader, movie, propertyName, cancellationToken);
                    break;
            }
        }
    }
}
