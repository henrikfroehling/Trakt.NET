namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class MostPWCShowJsonIOFactory : IJsonIOFactory<ITraktMostPWCShow>
    {
        public IObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new MostPWCShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCShow> CreateArrayReader() => new MostPWCShowArrayJsonReader();

        public IObjectJsonWriter<ITraktMostPWCShow> CreateObjectWriter() => new MostPWCShowObjectJsonWriter();

        public IArrayJsonWriter<ITraktMostPWCShow> CreateArrayWriter() => new MostPWCShowArrayJsonWriter();
    }
}
