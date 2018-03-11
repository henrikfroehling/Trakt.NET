namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationArrayJsonReader : AArrayJsonReader<ITraktCertification>
    {
        public override async Task<IEnumerable<ITraktCertification>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCertification>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var certificationReader = new CertificationObjectJsonReader();
                //var certificationReadingTasks = new List<Task<ITraktCertification>>();
                var certifications = new List<ITraktCertification>();

                //certificationReadingTasks.Add(certificationReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCertification certification = await certificationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (certification != null)
                {
                    certifications.Add(certification);
                    //certificationReadingTasks.Add(certificationReader.ReadObjectAsync(jsonReader, cancellationToken));
                    certification = await certificationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCertifications = await Task.WhenAll(certificationReadingTasks);
                //return (IEnumerable<ITraktCertification>)readCertifications.GetEnumerator();
                return certifications;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCertification>));
        }
    }
}
