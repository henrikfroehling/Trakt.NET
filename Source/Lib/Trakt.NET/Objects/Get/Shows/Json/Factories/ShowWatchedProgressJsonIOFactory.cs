namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowWatchedProgressJsonIOFactory : IJsonIOFactory<ITraktShowWatchedProgress>
    {
        public IObjectJsonReader<ITraktShowWatchedProgress> CreateObjectReader() => new ShowWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowWatchedProgress> CreateArrayReader() => new ShowWatchedProgressArrayJsonReader();

        public IObjectJsonWriter<ITraktShowWatchedProgress> CreateObjectWriter() => new ShowWatchedProgressObjectJsonWriter();
    }
}
