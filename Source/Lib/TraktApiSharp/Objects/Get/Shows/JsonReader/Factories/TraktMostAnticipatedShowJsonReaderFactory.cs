namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMostAnticipatedShowJsonReaderFactory : IJsonReaderFactory<ITraktMostAnticipatedShow>
    {
        public ITraktObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new TraktMostAnticipatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader() => new TraktMostAnticipatedShowArrayJsonReader();
    }
}
