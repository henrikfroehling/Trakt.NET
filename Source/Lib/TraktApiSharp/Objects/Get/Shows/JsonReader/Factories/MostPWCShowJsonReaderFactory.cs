namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class MostPWCShowJsonReaderFactory : IJsonReaderFactory<ITraktMostPWCShow>
    {
        public IObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new MostPWCShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCShow> CreateArrayReader() => new MostPWCShowArrayJsonReader();
    }
}
