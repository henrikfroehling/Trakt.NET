namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendedShowObjectJsonWriter : AShowObjectJsonWriter<ITraktRecommendedShow>
    {
        protected override async Task WriteShowObjectAsync(JsonTextWriter jsonWriter, ITraktRecommendedShow obj, CancellationToken cancellationToken = default)
        {
            await base.WriteShowObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.FavoritedBy != null)
            {
                var favoritedByArrayJsonWriter = new ArrayJsonWriter<ITraktFavoritedBy>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FAVORITED_BY, cancellationToken).ConfigureAwait(false);
                await favoritedByArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.FavoritedBy, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
