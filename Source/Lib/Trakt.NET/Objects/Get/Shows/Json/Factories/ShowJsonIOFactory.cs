namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowJsonIOFactory : IJsonIOFactory<ITraktShow>
    {
        public IObjectJsonReader<ITraktShow> CreateObjectReader() => new ShowObjectJsonReader();

        public IObjectJsonWriter<ITraktShow> CreateObjectWriter() => new ShowObjectJsonWriter();
    }
}
