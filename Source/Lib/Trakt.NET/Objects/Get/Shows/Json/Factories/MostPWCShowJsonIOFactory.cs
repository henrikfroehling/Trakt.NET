namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class MostPWCShowJsonIOFactory : IJsonIOFactory<ITraktMostPWCShow>
    {
        public IObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new MostPWCShowObjectJsonReader();

        public IObjectJsonWriter<ITraktMostPWCShow> CreateObjectWriter() => new MostPWCShowObjectJsonWriter();
    }
}
