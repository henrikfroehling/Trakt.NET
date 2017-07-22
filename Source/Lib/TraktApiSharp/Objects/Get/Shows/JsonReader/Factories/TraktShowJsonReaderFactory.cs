namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktShow>
    {
        public ITraktObjectJsonReader<ITraktShow> CreateObjectReader() => new TraktShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShow> CreateArrayReader() => new TraktShowArrayJsonReader();
    }
}
