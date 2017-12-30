namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;
    using System;

    internal class ShowWatchedProgressJsonReaderFactory : IJsonIOFactory<ITraktShowWatchedProgress>
    {
        public IObjectJsonReader<ITraktShowWatchedProgress> CreateObjectReader() => new ShowWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowWatchedProgress> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowWatchedProgress)} is not supported.");
        }

        public IObjectJsonReader<ITraktShowWatchedProgress> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktShowWatchedProgress> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
