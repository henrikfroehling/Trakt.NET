namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class MostAnticipatedShowJsonIOFactory : IJsonIOFactory<ITraktMostAnticipatedShow>
    {
        public IObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new MostAnticipatedShowObjectJsonReader();

        public IObjectJsonWriter<ITraktMostAnticipatedShow> CreateObjectWriter() => new MostAnticipatedShowObjectJsonWriter();
    }
}
