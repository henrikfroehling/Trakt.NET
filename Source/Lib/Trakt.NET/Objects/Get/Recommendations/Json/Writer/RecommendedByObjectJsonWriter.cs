namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Json.Writer;

    internal class RecommendedByObjectJsonWriter : AObjectJsonWriter<ITraktRecommendedBy>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRecommendedBy obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.User != null)
            {
                var userObjectJsonWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.User, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Notes))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Notes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
