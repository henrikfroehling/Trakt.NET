namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CertificationJsonReaderFactory : IJsonReaderFactory<ITraktCertification>
    {
        public IObjectJsonReader<ITraktCertification> CreateObjectReader() => new CertificationObjectJsonReader();

        public IArrayJsonReader<ITraktCertification> CreateArrayReader() => new CertificationArrayJsonReader();
    }
}
