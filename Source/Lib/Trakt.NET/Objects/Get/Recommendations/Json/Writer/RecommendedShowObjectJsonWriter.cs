namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendedShowObjectJsonWriter : AShowObjectJsonWriter<ITraktRecommendedShow>
    {
        protected override async Task WriteShowObjectAsync(JsonTextWriter jsonWriter, ITraktRecommendedShow obj, CancellationToken cancellationToken = default)
        {
            await base.WriteShowObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.RecommendedBy != null)
            {
                var recommendedByArrayJsonWriter = new ArrayJsonWriter<ITraktRecommendedBy>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RECOMMENDED_BY, cancellationToken).ConfigureAwait(false);
                await recommendedByArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.RecommendedBy, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
