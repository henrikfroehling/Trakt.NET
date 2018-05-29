namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationsObjectJsonReader : AObjectJsonReader<ITraktCertifications>
    {
        public override async Task<ITraktCertifications> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCertifications));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var certificationsArrayReader = new CertificationArrayJsonReader();
                ITraktCertifications traktCertifications = new TraktCertifications();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CERTIFICATIONS_PROPERTY_NAME_US:
                            traktCertifications.US = await certificationsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCertifications;
            }

            return await Task.FromResult(default(ITraktCertifications));
        }
    }
}
