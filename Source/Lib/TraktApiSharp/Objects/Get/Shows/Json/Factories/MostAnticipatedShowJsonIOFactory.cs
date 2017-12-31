namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class MostAnticipatedShowJsonIOFactory : IJsonIOFactory<ITraktMostAnticipatedShow>
    {
        public IObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new MostAnticipatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader() => new MostAnticipatedShowArrayJsonReader();

        public IObjectJsonWriter<ITraktMostAnticipatedShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMostAnticipatedShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
