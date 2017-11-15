namespace TraktApiSharp.Objects.Basic.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationArrayJsonReader : IArrayJsonReader<ITraktCertification>
    {
        public Task<IEnumerable<ITraktCertification>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCertification>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCertification>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCertification>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCertification>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
