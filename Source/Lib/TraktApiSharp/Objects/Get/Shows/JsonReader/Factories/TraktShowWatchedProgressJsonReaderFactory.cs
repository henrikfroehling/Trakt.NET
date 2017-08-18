namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktShowWatchedProgress>
    {
        public ITraktObjectJsonReader<ITraktShowWatchedProgress> CreateObjectReader() => new TraktShowWatchedProgressObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowWatchedProgress> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowWatchedProgress)} is not supported.");
        }
    }
}
