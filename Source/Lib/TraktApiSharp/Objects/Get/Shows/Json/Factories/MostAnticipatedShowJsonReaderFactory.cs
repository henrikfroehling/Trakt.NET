namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;

    internal class MostAnticipatedShowJsonReaderFactory : IJsonReaderFactory<ITraktMostAnticipatedShow>
    {
        public IObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new MostAnticipatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader() => new MostAnticipatedShowArrayJsonReader();
    }
}
