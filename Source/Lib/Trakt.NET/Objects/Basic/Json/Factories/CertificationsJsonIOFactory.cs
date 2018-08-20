namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CertificationsJsonIOFactory : IJsonIOFactory<ITraktCertifications>
    {
        public IObjectJsonReader<ITraktCertifications> CreateObjectReader() => new CertificationsObjectJsonReader();

        public IArrayJsonReader<ITraktCertifications> CreateArrayReader() => new CertificationsArrayJsonReader();

        public IObjectJsonWriter<ITraktCertifications> CreateObjectWriter() => new CertificationsObjectJsonWriter();
    }
}
