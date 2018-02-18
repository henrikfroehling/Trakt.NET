namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationsObjectJsonWriter : AObjectJsonWriter<ITraktCertifications>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCertifications obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.US != null)
            {
                var certificationArrayJsonWriter = new ArrayJsonWriter<ITraktCertification>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CERTIFICATIONS_PROPERTY_NAME_US, cancellationToken).ConfigureAwait(false);
                await certificationArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.US, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
