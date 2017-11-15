namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;

    internal class MostPWCShowJsonReaderFactory : IJsonReaderFactory<ITraktMostPWCShow>
    {
        public IObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new MostPWCShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCShow> CreateArrayReader() => new MostPWCShowArrayJsonReader();
    }
}
