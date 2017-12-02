namespace TraktApiSharp.Objects.Get.Shows.Json.Factories.Reader
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class MostAnticipatedShowJsonReaderFactory : IJsonReaderFactory<ITraktMostAnticipatedShow>
    {
        public IObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new MostAnticipatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader() => new MostAnticipatedShowArrayJsonReader();
    }
}
