namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class CertificationsJsonReaderFactory : IJsonIOFactory<ITraktCertifications>
    {
        public IObjectJsonReader<ITraktCertifications> CreateObjectReader() => new CertificationsObjectJsonReader();

        public IArrayJsonReader<ITraktCertifications> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCertifications)} is not supported.");
        }

        public IObjectJsonReader<ITraktCertifications> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktCertifications> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
