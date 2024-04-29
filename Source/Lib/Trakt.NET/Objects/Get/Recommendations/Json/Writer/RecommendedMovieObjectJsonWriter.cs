namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendedMovieObjectJsonWriter : AMovieObjectJsonWriter<ITraktRecommendedMovie>
    {
        protected override async Task WriteMovieObjectAsync(JsonTextWriter jsonWriter, ITraktRecommendedMovie obj, CancellationToken cancellationToken = default)
        {
            await base.WriteMovieObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.FavoritedBy != null)
            {
                var favoritedByArrayJsonWriter = new ArrayJsonWriter<ITraktFavoritedBy>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FAVORITED_BY, cancellationToken).ConfigureAwait(false);
                await favoritedByArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.FavoritedBy, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
