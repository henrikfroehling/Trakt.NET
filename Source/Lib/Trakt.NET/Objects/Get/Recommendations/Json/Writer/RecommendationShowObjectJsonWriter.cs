namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecommendationShowObjectJsonWriter : ARecommendationObjectJsonWriter<ITraktRecommendationShow>
    {
        protected override async Task WriteRecommendationObjectAsync(JsonTextWriter jsonWriter, ITraktRecommendationShow obj, CancellationToken cancellationToken = default)
        {
            await base.WriteRecommendationObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
