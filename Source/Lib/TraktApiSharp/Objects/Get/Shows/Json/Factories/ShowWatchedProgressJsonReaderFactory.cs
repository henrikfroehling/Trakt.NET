namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;
    using System;

    internal class ShowWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktShowWatchedProgress>
    {
        public IObjectJsonReader<ITraktShowWatchedProgress> CreateObjectReader() => new ShowWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowWatchedProgress> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowWatchedProgress)} is not supported.");
        }
    }
}
