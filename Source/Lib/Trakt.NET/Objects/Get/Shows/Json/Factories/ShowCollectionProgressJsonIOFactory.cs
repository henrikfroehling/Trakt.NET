namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowCollectionProgressJsonIOFactory : IJsonIOFactory<ITraktShowCollectionProgress>
    {
        public IObjectJsonReader<ITraktShowCollectionProgress> CreateObjectReader() => new ShowCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowCollectionProgress> CreateArrayReader() => new ShowCollectionProgressArrayJsonReader();

        public IObjectJsonWriter<ITraktShowCollectionProgress> CreateObjectWriter() => new ShowCollectionProgressObjectJsonWriter();
    }
}
