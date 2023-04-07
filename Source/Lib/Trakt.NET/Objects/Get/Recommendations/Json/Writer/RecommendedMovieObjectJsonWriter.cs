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

            if (obj.RecommendedBy != null)
            {
                var recommendedByArrayJsonWriter = new ArrayJsonWriter<ITraktRecommendedBy>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RECOMMENDED_BY, cancellationToken).ConfigureAwait(false);
                await recommendedByArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.RecommendedBy, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
