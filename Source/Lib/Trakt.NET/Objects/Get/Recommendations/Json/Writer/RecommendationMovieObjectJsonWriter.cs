namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationMovieObjectJsonWriter : ARecommendationObjectJsonWriter<ITraktRecommendationMovie>
    {
        protected override async Task WriteRecommendationObjectAsync(JsonTextWriter jsonWriter, ITraktRecommendationMovie obj, CancellationToken cancellationToken = default)
        {
            await base.WriteRecommendationObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
