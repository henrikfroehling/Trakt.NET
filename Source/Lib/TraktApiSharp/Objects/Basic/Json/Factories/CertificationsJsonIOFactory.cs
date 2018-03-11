namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class CertificationsJsonIOFactory : IJsonIOFactory<ITraktCertifications>
    {
        public IObjectJsonReader<ITraktCertifications> CreateObjectReader() => new CertificationsObjectJsonReader();

        public IArrayJsonReader<ITraktCertifications> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktCertifications)} is not supported.");

        public IObjectJsonWriter<ITraktCertifications> CreateObjectWriter() => new CertificationsObjectJsonWriter();
    }
}
