namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktStatisticsJsonReaderFactory : ITraktJsonReaderFactory<ITraktStatistics>
    {
        public ITraktObjectJsonReader<ITraktStatistics> CreateObjectReader() => new TraktStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktStatistics)} is not supported.");
        }
    }
}
