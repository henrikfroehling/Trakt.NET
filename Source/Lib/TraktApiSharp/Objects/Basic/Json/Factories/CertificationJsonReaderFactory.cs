namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class CertificationJsonReaderFactory : IJsonIOFactory<ITraktCertification>
    {
        public IObjectJsonReader<ITraktCertification> CreateObjectReader() => new CertificationObjectJsonReader();

        public IArrayJsonReader<ITraktCertification> CreateArrayReader() => new CertificationArrayJsonReader();

        public IObjectJsonReader<ITraktCertification> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCertification> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
