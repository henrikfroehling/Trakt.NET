namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;

    internal class ShowJsonReaderFactory : IJsonReaderFactory<ITraktShow>
    {
        public IObjectJsonReader<ITraktShow> CreateObjectReader() => new ShowObjectJsonReader();

        public IArrayJsonReader<ITraktShow> CreateArrayReader() => new ShowArrayJsonReader();
    }
}
