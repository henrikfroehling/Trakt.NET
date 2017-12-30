namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class MostPWCShowJsonReaderFactory : IJsonIOFactory<ITraktMostPWCShow>
    {
        public IObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new MostPWCShowObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCShow> CreateArrayReader() => new MostPWCShowArrayJsonReader();

        public IObjectJsonReader<ITraktMostPWCShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMostPWCShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
