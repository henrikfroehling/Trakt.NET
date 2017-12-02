namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class CertificationsJsonReaderFactory : IJsonReaderFactory<ITraktCertifications>
    {
        public IObjectJsonReader<ITraktCertifications> CreateObjectReader() => new CertificationsObjectJsonReader();

        public IArrayJsonReader<ITraktCertifications> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCertifications)} is not supported.");
        }
    }
}
