namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowIdsJsonIOFactory : IJsonIOFactory<ITraktShowIds>
    {
        public IObjectJsonReader<ITraktShowIds> CreateObjectReader() => new ShowIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktShowIds> CreateObjectWriter() => new ShowIdsObjectJsonWriter();
    }
}
