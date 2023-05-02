namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCertificationObjectJsonWriter : AObjectJsonWriter<ITraktShowCertification>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowCertification obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Certification))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CERTIFICATION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Certification, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.CountryCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COUNTRY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CountryCode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
