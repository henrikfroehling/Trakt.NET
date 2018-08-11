namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowAirsJsonIOFactory : IJsonIOFactory<ITraktShowAirs>
    {
        public IObjectJsonReader<ITraktShowAirs> CreateObjectReader() => new ShowAirsObjectJsonReader();

        public IArrayJsonReader<ITraktShowAirs> CreateArrayReader() => new ShowAirsArrayJsonReader();

        public IObjectJsonWriter<ITraktShowAirs> CreateObjectWriter() => new ShowAirsObjectJsonWriter();
    }
}
