namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
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
