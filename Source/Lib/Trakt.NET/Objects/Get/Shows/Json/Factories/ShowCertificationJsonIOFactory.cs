namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowCertificationJsonIOFactory : IJsonIOFactory<ITraktShowCertification>
    {
        public IObjectJsonReader<ITraktShowCertification> CreateObjectReader() => new ShowCertificationObjectJsonReader();

        public IObjectJsonWriter<ITraktShowCertification> CreateObjectWriter() => new ShowCertificationObjectJsonWriter();
    }
}
