namespace TraktApiSharp.Objects.Get.Shows.Json.Factories.Reader
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowJsonReaderFactory : IJsonReaderFactory<ITraktShow>
    {
        public IObjectJsonReader<ITraktShow> CreateObjectReader() => new ShowObjectJsonReader();

        public IArrayJsonReader<ITraktShow> CreateArrayReader() => new ShowArrayJsonReader();
    }
}
