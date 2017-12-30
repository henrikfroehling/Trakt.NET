namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class MostAnticipatedShowJsonReaderFactory : IJsonIOFactory<ITraktMostAnticipatedShow>
    {
        public IObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new MostAnticipatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader() => new MostAnticipatedShowArrayJsonReader();

        public IObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
