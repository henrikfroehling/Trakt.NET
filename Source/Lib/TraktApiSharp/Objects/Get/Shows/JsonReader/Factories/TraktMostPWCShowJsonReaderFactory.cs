namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMostPWCShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktMostPWCShow>
    {
        public ITraktObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new TraktMostPWCShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostPWCShow> CreateArrayReader() => new TraktMostPWCShowArrayJsonReader();
    }
}
