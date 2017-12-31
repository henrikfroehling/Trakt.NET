namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowJsonIOFactory : IJsonIOFactory<ITraktShow>
    {
        public IObjectJsonReader<ITraktShow> CreateObjectReader() => new ShowObjectJsonReader();

        public IArrayJsonReader<ITraktShow> CreateArrayReader() => new ShowArrayJsonReader();

        public IObjectJsonWriter<ITraktShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
