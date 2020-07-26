namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationsArrayJsonReader : ArrayJsonReader<ITraktCertifications>
    {
        public override async Task<IEnumerable<ITraktCertifications>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCertifications>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var certificationsReader = new CertificationsObjectJsonReader();
                var certificationss = new List<ITraktCertifications>();
                ITraktCertifications certifications = await certificationsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (certifications != null)
                {
                    certificationss.Add(certifications);
                    certifications = await certificationsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return certificationss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCertifications>));
        }
    }
}
