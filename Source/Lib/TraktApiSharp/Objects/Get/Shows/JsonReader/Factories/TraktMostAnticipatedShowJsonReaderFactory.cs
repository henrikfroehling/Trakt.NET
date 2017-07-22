namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMostAnticipatedShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktMostAnticipatedShow>
    {
        public ITraktObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new TraktMostAnticipatedShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader() => new TraktMostAnticipatedShowArrayJsonReader();
    }
}
