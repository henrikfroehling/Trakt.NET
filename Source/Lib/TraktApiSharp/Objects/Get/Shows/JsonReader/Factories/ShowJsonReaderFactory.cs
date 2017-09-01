namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class ShowJsonReaderFactory : IJsonReaderFactory<ITraktShow>
    {
        public IObjectJsonReader<ITraktShow> CreateObjectReader() => new ShowObjectJsonReader();

        public IArrayJsonReader<ITraktShow> CreateArrayReader() => new ShowArrayJsonReader();
    }
}
