namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktShowJsonReaderFactory : IJsonReaderFactory<ITraktShow>
    {
        public ITraktObjectJsonReader<ITraktShow> CreateObjectReader() => new TraktShowObjectJsonReader();

        public IArrayJsonReader<ITraktShow> CreateArrayReader() => new TraktShowArrayJsonReader();
    }
}
