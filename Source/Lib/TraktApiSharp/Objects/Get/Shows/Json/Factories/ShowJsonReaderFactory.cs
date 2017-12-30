namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowJsonReaderFactory : IJsonIOFactory<ITraktShow>
    {
        public IObjectJsonReader<ITraktShow> CreateObjectReader() => new ShowObjectJsonReader();

        public IArrayJsonReader<ITraktShow> CreateArrayReader() => new ShowArrayJsonReader();

        public IObjectJsonReader<ITraktShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
